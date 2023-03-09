using btr.application.PurchaseContext.SupplierAgg.Contracts;
using btr.domain.PurchaseContext.SupplierAgg;
using Nuna.Lib.AutoNumberHelper;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.DataTypeExtension;

namespace btr.application.PurchaseContext.SupplierAgg.Workers;

public  interface ISupplierWriter : INunaWriter<SupplierModel>
{
}

public class SupplierWriter : ISupplierWriter
{
    private readonly INunaCounterBL _counter;
    private readonly ISupplierDal _supplierDal;

    public SupplierWriter(ISupplierDal supplierDal, 
        INunaCounterBL counter)
    {
        _counter = counter;
        _supplierDal = supplierDal;
    }

    public void Save(ref SupplierModel model)
    {
        if (model.SupplierId.IsNullOrEmpty())
            model.SupplierId = _counter.Generate("SP", IDFormatEnum.PFnnn);
        var db = _supplierDal.GetData(model);
        if (db is null)
            _supplierDal.Insert(model);
        else
            _supplierDal.Update(model);
    }
}
