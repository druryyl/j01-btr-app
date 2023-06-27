using btr.domain.InventoryContext.BrgAgg;
using btr.domain.InventoryContext.StokAgg;
using btr.domain.InventoryContext.WarehouseAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.InventoryContext.StokAgg.Contracts;

public interface IStokDal :
    IInsert<StokModel>,
    IUpdate<StokModel>,
    IDelete<IStokKey>,
    IGetData<StokModel, IStokKey>,
    IListData<StokModel, IBrgKey, IWarehouseKey>
{
    IEnumerable<StokModel> ListDataAll(IBrgKey brg, IWarehouseKey warehouse);
}