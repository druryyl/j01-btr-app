using btr.application.InventoryContext.WarehouseAgg.Contracts;
using btr.application.SalesContext.CustomerAgg.Contracts;
using btr.application.SalesContext.SalesPersonAgg.Contracts;
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
    IFakturBuilder FakturDate(DateTime fakturDate);
    IFakturBuilder Customer(ICustomerKey customerKey);
    IFakturBuilder SalesPerson(ISalesPersonKey salesPersonKey);
    IFakturBuilder Warehouse(IWarehouseKey warehouseKey);
    
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
            LastUpdate = new DateTime(3000,1,1),
            UserId = 
        }
    }

    public IFakturBuilder FakturDate(DateTime fakturDate)
    {
        throw new NotImplementedException();
    }

    public IFakturBuilder Customer(ICustomerKey customerKey)
    {
        throw new NotImplementedException();
    }

    public IFakturBuilder SalesPerson(ISalesPersonKey salesPersonKey)
    {
        throw new NotImplementedException();
    }

    public IFakturBuilder Warehouse(IWarehouseKey warehouseKey)
    {
        throw new NotImplementedException();
    }
}