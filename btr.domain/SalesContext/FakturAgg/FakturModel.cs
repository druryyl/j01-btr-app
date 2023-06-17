namespace btr.domain.SalesContext.FakturAgg;

public class FakturModel : IFakturKey
{
    public string FakturId { get; set; }
}

public interface IFakturKey
{
    string FakturId { get; }
}