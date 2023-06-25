﻿using btr.domain.InventoryContext.BrgAgg;

namespace btr.domain.SalesContext.FakturAgg;

public class FakturItemModel : IFakturKey, IFakturItemKey, IBrgKey
{
    public string FakturItemId { get; set; }
    public string FakturId { get; set; }
    public int ItemNo { get; set; }
    public string BrgId { get; set; }
    public string BrgName { get; set; }
    
    public int AvailableQty { get; set; }
    public int Qty { get; set; }
    public double HargaJual { get; set; }
    public double SubTotal { get; set; }
    public double DiscountRp { get; set; }
    public double PpnProsen { get; set; }
    public double PpnRp { get; set; }
    public double Total { get; set; }
    
    public List<FakturStokHargaModel> ListStokHarga { get; set; }
    public List<FakturDiscountModel> ListDiscount { get; set; }
}