using btr.domain.InventoryContext.WarehouseAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.InventoryContext.WarehouseAgg.Contracts;

public interface IWarehouseDal :
    IInsert<WarehouseModel>,
    IUpdate<WarehouseModel>,
    IDelete<IWarehouseKey>,
    IGetData<WarehouseModel, IWarehouseKey>,
    IListData<WarehouseModel>
{
}