using btr.domain.SalesContext.FakturAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.SalesContext.FakturAgg.Contracts;

public interface  IFakturQtyHargaDal :
    IInsertBulk<FakturQtyHargaModel>,
    IDelete<IFakturKey>,
    IListData<FakturQtyHargaModel, IFakturKey>
{
}