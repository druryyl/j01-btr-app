using btr.domain.SalesContext.FakturAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.SalesContext.FakturAgg.Contracts;

public interface  IFakturDiscountDal :
    IInsertBulk<FakturDiscountModel>,
    IDelete<IFakturKey>,
    IListData<FakturDiscountModel, IFakturKey>
{
}