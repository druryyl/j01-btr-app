using btr.domain.SalesContext.FakturAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.SalesContext.FakturAgg.Contracts;

public interface  IFakturStokHargaDal :
    IInsertBulk<FakturStokHargaModel>,
    IDelete<IFakturKey>,
    IListData<FakturStokHargaModel, IFakturKey>
{
}