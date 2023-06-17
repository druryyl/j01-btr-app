namespace btr.domain.InventoryContext.WarehouseAgg;

public class WarehouseModel : IWarehouseKey
{
    public string WarehouseId { get; }
    public string WarehouseName { get; set; }
}