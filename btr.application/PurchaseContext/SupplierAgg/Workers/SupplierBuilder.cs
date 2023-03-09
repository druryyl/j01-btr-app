using btr.domain.PurchaseContext.SupplierAgg;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.application.PurchaseContext.SupplierAgg.Workers;

public interface ISupplierBuilder : INunaBuilder<SupplierModel>
{
    ISupplierBuilder CreateNew();
    ISupplierBuilder Name(string name);
}

public class SupplierBuilder : ISupplierBuilder
{
    private SupplierModel _aggRoot;
    public SupplierModel Build()
    {
        _aggRoot.RemoveNull();
        return _aggRoot;
    }

    public ISupplierBuilder CreateNew()
    {
        _aggRoot = new SupplierModel();
        return this;
    }

    public ISupplierBuilder Name(string name)
    {
        _aggRoot.SupplierName = name;
        return this;
    }
}
