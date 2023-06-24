using btr.domain.SalesContext.FakturAgg;
using Nuna.Lib.CleanArchHelper;

namespace btr.application.SalesContext.FakturAgg.Workers;

public interface IFakturWriter : INunaWriter<FakturModel>
{
}
public class FakturWriter : IFakturWriter
{
    public void Save(ref FakturModel model)
    {
        throw new NotImplementedException();
    }
}