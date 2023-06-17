namespace btr.domain.InventoryContext.DeliveryAgg;

public class DeliveryModel : IDeliveryKey
{
    public string DeliveryId { get; set; }
    public DateTime DeliveryDate { get; set; }
}

public interface IDeliveryKey
{
    string DeliveryId { get; }
}