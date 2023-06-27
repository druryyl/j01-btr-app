using btr.domain.InventoryContext.StokAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.InventoryContext.StokAgg.Contracts;

public interface IStokMutasiDal :
    IInsertBulk<StokMutasiModel>,
    IDelete<IStokKey>,
    IListData<StokMutasiModel, IStokKey>
{
}