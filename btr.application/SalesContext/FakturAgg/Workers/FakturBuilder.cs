using btr.application.InventoryContext.BrgAgg.Contracts;
using btr.application.InventoryContext.WarehouseAgg.Contracts;
using btr.application.SalesContext.CustomerAgg.Contracts;
using btr.application.SalesContext.SalesPersonAgg.Contracts;
using btr.domain.InventoryContext.BrgAgg;
using btr.domain.InventoryContext.WarehouseAgg;
using btr.domain.SalesContext.CustomerAgg;
using btr.domain.SalesContext.FakturAgg;
using btr.domain.SalesContext.SalesPersonAgg;
using btr.domain.SupportContext.UserAgg;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.application.SalesContext.FakturAgg.Workers;

public interface IFakturBuilder : INunaBuilder<FakturModel>
{
    IFakturBuilder CreateNew(IUserKey userKey);
    IFakturBuilder Attach(FakturModel faktur);
    IFakturBuilder FakturDate(DateTime fakturDate);
    IFakturBuilder Customer(ICustomerKey customerKey);
    IFakturBuilder SalesPerson(ISalesPersonKey salesPersonKey);
    IFakturBuilder Warehouse(IWarehouseKey warehouseKey);
    IFakturBuilder AddItem(IBrgKey brgKey, string qtyString, string discountString, double ppnProsen);

}
public class FakturBuilder : IFakturBuilder
{
    private FakturModel _aggRoot = new();
    private readonly ICustomerDal _customerDal;
    private readonly ISalesPersonDal _salesPersonDal;
    private readonly IWarehouseDal _warehouseDal;
    private readonly IBrgDal _brgDal;
    private readonly DateTimeProvider _dateTime;

    public FakturBuilder(ICustomerDal customerDal, 
        ISalesPersonDal salesPersonDal, 
        IWarehouseDal warehouseDal, 
        IBrgDal brgDal, 
        DateTimeProvider dateTime)
    {
        _customerDal = customerDal;
        _salesPersonDal = salesPersonDal;
        _warehouseDal = warehouseDal;
        _brgDal = brgDal;
        _dateTime = dateTime;
    }

    public FakturModel Build()
    {
        _aggRoot.RemoveNull();
        return _aggRoot;
    }

    public IFakturBuilder CreateNew(IUserKey userKey)
    {
        _aggRoot = new FakturModel
        {
            CreateTime = _dateTime.Now,
            LastUpdate = new DateTime(3000, 1, 1),
            UserId = userKey.UserId
        };
        return this;
    }

    public IFakturBuilder Attach(FakturModel faktur)
    {
        _aggRoot = faktur;
        return this;
    }

    public IFakturBuilder FakturDate(DateTime fakturDate)
    {
        _aggRoot.FakturDate = fakturDate;
        return this;
    }

    public IFakturBuilder Customer(ICustomerKey customerKey)
    {
        var customer = _customerDal.GetData(customerKey)
            ?? throw new KeyNotFoundException($"CustomerId not found ({customerKey.CustomerId})");
        _aggRoot.CustomerId = customer.CustomerId;
        _aggRoot.CustomerName = customer.CustomerName;
        _aggRoot.Plafond = customer.Plafond;
        _aggRoot.CreditBalance = customer.CreditBalance;
        return this;
    }

    public IFakturBuilder SalesPerson(ISalesPersonKey salesPersonKey)
    {
        var salesPerson = _salesPersonDal.GetData(salesPersonKey)
            ?? throw new KeyNotFoundException($"SalesPersonId not found ({salesPersonKey.SalesPersonId})");
        _aggRoot.SalesPersonId = salesPerson.SalesPersonId;
        _aggRoot.SalesPersonName = salesPerson.SalesPersonName;
        return this;
    }

    public IFakturBuilder Warehouse(IWarehouseKey warehouseKey)
    {
        var warehouse = _warehouseDal.GetData(warehouseKey)
            ?? throw new KeyNotFoundException($"WarehouseId not found ({warehouseKey.WarehouseId})");
        _aggRoot.WarehouseId = warehouse.WarehouseId;
        _aggRoot.WarehouseName = warehouse.WarehouseName;
        return this;
    }

    public IFakturBuilder AddItem(IBrgKey brgKey, string qtyString, 
        string discountString, double ppnProsen)
    {
        var itemNoMax = _aggRoot.ListItem
            .DefaultIfEmpty(new FakturItemModel() { ItemNo = 0 })
            .Max(x => x.ItemNo);
        var itemNo = itemNoMax + 1;
        
        var brg = _brgDal.GetData(brgKey)
            ?? throw new KeyNotFoundException($"BrgId not found ({brgKey.BrgId})");
        var newItem = new FakturItemModel
        {
            BrgId = brgKey.BrgId,
            BrgName = brg.BrgName,
            ItemNo = itemNo,
            ListQtyHarga = GenListStokHarga(brg, qtyString).ToList(),
        };
        newItem.Qty = newItem.ListQtyHarga.Sum(x => x.Qty * x.KonversiSatuan);
        newItem.SubTotal = newItem.ListQtyHarga.Sum(x => x.Qty * x.HargaJual);

        newItem.ListDiscount = GenListDiscount(newItem.SubTotal, discountString).ToList();
        newItem.DiscountRp = newItem.ListDiscount.Sum(x => x.DiscountRp);
        newItem.PpnProsen = 11;
        newItem.PpnRp = (newItem.SubTotal - newItem.DiscountRp) * 0.11;
        newItem.Total = newItem.SubTotal - newItem.DiscountRp + newItem.PpnRp;
        
        _aggRoot.ListItem.Add(newItem);
        return this;
    }

    private static IEnumerable<FakturQtyHargaModel> GenListStokHarga(BrgModel brg, string qtyString)
    {
        var result = new List<FakturQtyHargaModel>();
        var qtys = ParseStringMultiNumber(qtyString, 3);
        var satuanBesar = brg.ListSatuan.OrderBy(x => x.Conversion).Last();
        var satuanKecil = brg.ListSatuan.OrderBy(x => x.Conversion).First();
        var hrgBesar = brg.ListHarga.FirstOrDefault(x => x.Satuan == satuanBesar.Satuan)?.HargaJual??0;        
        var hrgKecil = brg.ListHarga.FirstOrDefault(x => x.Satuan == satuanKecil.Satuan)?.HargaJual??0;

        result.Add(new FakturQtyHargaModel(1, brg.BrgId, satuanBesar.Satuan, 
            satuanBesar.Conversion, (int)qtys[0], hrgBesar));
        result.Add(new FakturQtyHargaModel(2, brg.BrgId, satuanKecil.Satuan, 
            satuanKecil.Conversion, (int)qtys[1], hrgKecil));
        result.Add(new FakturQtyHargaModel(3, brg.BrgId, satuanKecil.Satuan, 
            satuanKecil.Conversion, (int)qtys[2], 0));
        result.RemoveAll(x => x.Qty == 0);
        
        return result;
    }
    
    private static IEnumerable<FakturDiscountModel> GenListDiscount(double subTotal, string disccountString)
    {
        var discs = ParseStringMultiNumber(disccountString, 4);

        var discRp = new double[4];
        discRp[0] = subTotal * discs[0] / 100;
        var newSubTotal = subTotal - discRp[0];
        discRp[1] = newSubTotal * discs[1] / 100;
        newSubTotal -= discRp[1];
        discRp[2] = newSubTotal * discs[2] / 100;
        newSubTotal -= discRp[2];
        discRp[3] = newSubTotal * discs[3] / 100;

        var result = new List<FakturDiscountModel>
        {
            new FakturDiscountModel(1, discs[0], discRp[0]),
            new FakturDiscountModel(2, discs[1], discRp[1]),
            new FakturDiscountModel(3,discs[2], discRp[2]),
            new FakturDiscountModel(4,discs[3], discRp[3])
        };
        result.RemoveAll(x => x.DiscountProsen == 0);
        return result;
    }    
    private static List<double> ParseStringMultiNumber(string str, int size)
    {
        var result = new List<double>();
        for (var i = 0; i < size; i++)
            result.Add(0);

        var resultStr = (str == string.Empty ? "0" : str).Split(';').ToList();

        var x = 0;
        foreach (var item in resultStr.TakeWhile(item => x < result.Count))
        {
            if (int.TryParse(item, out var temp))
                result[x] = temp;
            x++;
        }
        return result;
    }
}