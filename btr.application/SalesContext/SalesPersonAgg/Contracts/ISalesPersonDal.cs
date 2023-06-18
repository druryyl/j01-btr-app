using btr.domain.SalesContext.SalesPersonAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.SalesContext.SalesPersonAgg.Contracts;

public interface ISalesPersonDal :
    IInsert<SalesPersonModel>,
    IUpdate<SalesPersonModel>,
    IDelete<ISalesPersonKey>,
    IGetData<SalesPersonModel, ISalesPersonKey>,
    IListData<SalesPersonModel>
{
}