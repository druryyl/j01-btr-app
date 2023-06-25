using btr.domain.InventoryContext.BrgAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.InventoryContext.BrgAgg.Contracts;

public interface IBrgSatuanHargaDal :
    IInsertBulk<BrgSatuanHargaModel>,
    IDelete<IBrgKey>,
    IListData<BrgSatuanHargaModel, IBrgKey>
{
}