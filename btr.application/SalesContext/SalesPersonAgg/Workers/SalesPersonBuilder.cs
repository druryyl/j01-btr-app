using btr.application.SalesContext.SalesPersonAgg.Contracts;
using btr.domain.SalesContext.SalesPersonAgg;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.application.SalesContext.SalesPersonAgg.Workers;

public interface ISalesPersonBuilder : INunaBuilder<SalesPersonModel>
{
    ISalesPersonBuilder CreateNew(string name);
    ISalesPersonBuilder Load(ISalesPersonKey salesPersonKey);
}
public class SalesPersonBuilder : ISalesPersonBuilder
{
    private SalesPersonModel _aggRoot = new();
    private readonly ISalesPersonDal _salesPersonDal;

    public SalesPersonBuilder(ISalesPersonDal salesPersonDal)
    {
        _salesPersonDal = salesPersonDal;
    }

    public SalesPersonModel Build()
    {
        _aggRoot.RemoveNull();
        return _aggRoot;
    }

    public ISalesPersonBuilder CreateNew(string name)
    {
        _aggRoot = new SalesPersonModel
        {
            SalesPersonName = name
        };
        return this;
    }

    public ISalesPersonBuilder Load(ISalesPersonKey salesPersonKey)
    {
        _aggRoot = _salesPersonDal.GetData(salesPersonKey)
                   ?? throw new KeyNotFoundException($"SalesPersonId not found ({salesPersonKey.SalesPersonId})");
        return this;
    }
}