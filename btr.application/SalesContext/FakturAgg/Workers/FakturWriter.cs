using btr.application.SalesContext.FakturAgg.Contracts;
using btr.domain.SalesContext.FakturAgg;
using FluentValidation;
using Nuna.Lib.AutoNumberHelper;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.DataTypeExtension;
using Nuna.Lib.TransactionHelper;

namespace btr.application.SalesContext.FakturAgg.Workers;

public interface IFakturWriter : INunaWriter<FakturModel>
{
}
public class FakturWriter : IFakturWriter
{
    private readonly IFakturDal _fakturDal;
    private readonly IFakturItemDal _fakturItemDal;
    private readonly IFakturStokHargaDal _fakturStokHargaDal;
    private readonly IFakturDiscountDal _fakturDiscountDal;
    private readonly INunaCounterBL _counter;
    private readonly IValidator<FakturModel> _validator;

    public FakturWriter(IFakturDal fakturDal, 
        IFakturItemDal fakturItemDal, 
        IFakturStokHargaDal fakturStokHargaDal, 
        IFakturDiscountDal fakturDiscountDal, 
        INunaCounterBL counter, 
        IValidator<FakturModel> validator)
    {
        _fakturDal = fakturDal;
        _fakturItemDal = fakturItemDal;
        _fakturStokHargaDal = fakturStokHargaDal;
        _fakturDiscountDal = fakturDiscountDal;
        _counter = counter;
        _validator = validator;
    }

    public void Save(ref FakturModel model)
    {
        //  VALIDATE
        _validator.ValidateAndThrow(model);
        
        //  GENERATE-ID
        if (model.FakturId.IsNullOrEmpty())
            model.FakturId = _counter.Generate("FKTR", IDFormatEnum.PREFYYMnnnnnC);
        foreach (var item in model.ListItem)
        {
            item.FakturId = model.FakturId;
            item.FakturItemId = $"{model.FakturId}-{item.ItemNo:D2}";
            foreach (var item2 in item.ListQtyHarga)
            {
                item2.FakturId = model.FakturId;
                item2.FakturItemId = item.FakturItemId;
                item2.FakturStokHargaId = $"{item.FakturItemId}-{item2.QtyHargaNo:D1}";
            }
            foreach (var item2 in item.ListDiscount)
            {
                item2.FakturId = model.FakturId;
                item2.FakturItemId = item.FakturItemId;
                item2.FakturDiscountId = $"{item.FakturItemId}-{item2.DiscountNo:D1}";
            }
        }
        var allStokHarga = model.ListItem.SelectMany(x => x.ListQtyHarga, (hdr, dtl) => dtl);
        var allDiscount = model.ListItem.SelectMany(x => x.ListDiscount, (hdr, dtl) => dtl);
        
        //  WRITE
        using var trans = TransHelper.NewScope();

        var db = _fakturDal.GetData(model);
        if (db is null)
            _fakturDal.Insert(model);
        else
            _fakturDal.Update(model);

        _fakturItemDal.Delete(model);
        _fakturStokHargaDal.Delete(model);
        _fakturDiscountDal.Delete(model);

        _fakturItemDal.Insert(model.ListItem);
        _fakturStokHargaDal.Insert(allStokHarga);
        _fakturDiscountDal.Insert(allDiscount);
        
        trans.Complete();
    }
}