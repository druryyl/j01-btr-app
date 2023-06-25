using btr.domain.SalesContext.FakturAgg;
using Nuna.Lib.DataAccessHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.application.SalesContext.FakturAgg.Contracts;

public interface IFakturDal :
    IInsert<FakturModel>,
    IUpdate<FakturModel>,
    IDelete<IFakturKey>,
    IGetData<FakturModel, IFakturKey>,
    IListData<FakturModel, Periode>
{
}