using btr.domain.SalesContext.FakturAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.SalesContext.FakturAgg.Contracts;

public interface IFakturItemDal :
    IInsertBulk<FakturItemModel>,
    IDelete<IFakturKey>,
    IListData<FakturItemModel, IFakturKey>
{
}