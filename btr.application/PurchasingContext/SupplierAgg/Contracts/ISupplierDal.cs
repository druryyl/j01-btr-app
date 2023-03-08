using btr.domain.PurchasingContext.SupplierAgg;
using Nuna.Lib.DataAccessHelper;

namespace btr.application.PurchasingContext.SupplierAgg.Contracts;

public interface ISupplierDal :
    IGetData<SupplierModel, ISupplierKey>,
    IListData<SupplierModel>
{
}