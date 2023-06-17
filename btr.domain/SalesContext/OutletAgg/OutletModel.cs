namespace btr.domain.SalesContext.OutletAgg;

public class OutletModel : IOutletKey
{
    public string OutletId { get; set; }
    public string OutletName { get; set; }
}

public interface IOutletKey
{
    string OutletId { get; }
}