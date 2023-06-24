namespace btr.domain.SalesContext.FakturAgg;

public class FakturDiscountModel : IFakturKey, 
    IFakturItemKey, IFakturDiscountKey
{
    public string FakturId { get; set; }
    public string FakturItemId { get; set; }
    public string FakturDiscountId { get; set; }
    public string ItemNo { get; set; }
    public int DiscountNo { get; set; }

    public string BrgId { get; set; }
    public double DiscountProsen { get; set; }
    public double DiscountRp { get; set; }
}