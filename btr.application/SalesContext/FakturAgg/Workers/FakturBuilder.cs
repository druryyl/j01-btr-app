using btr.application.InventoryContext.WarehouseAgg.Contracts;
using btr.application.SalesContext.CustomerAgg.Contracts;
using btr.application.SalesContext.SalesPersonAgg.Contracts;
using btr.domain.InventoryContext.BrgAgg;
using btr.domain.InventoryContext.WarehouseAgg;
using btr.domain.SalesContext.FakturAgg;
using btr.domain.SalesContext.OutletAgg;
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
    private readonly DateTimeProvider _dateTime;

    public FakturBuilder(ICustomerDal customerDal, 
        ISalesPersonDal salesPersonDal, 
        IWarehouseDal warehouseDal, 
        DateTimeProvider dateTime)
    {
        _customerDal = customerDal;
        _salesPersonDal = salesPersonDal;
        _warehouseDal = warehouseDal;
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
        //  nomor urut set di sini juga
        throw new NotImplementedException();
    }
}