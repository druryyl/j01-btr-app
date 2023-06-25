using btr.domain.InventoryContext.BrgAgg;

namespace btr.domain.SalesContext.FakturAgg;

public class FakturQtyHargaModel : IFakturKey, 
    IFakturItemKey, IFakturStokHargaKey, IBrgKey
{
    public FakturQtyHargaModel()
    {
    }

    public FakturQtyHargaModel(int qtyHargaNo, string brgId, string satuan, 
        int konversiSatuan, int qty, double hargaJual)
    {
        QtyHargaNo = qtyHargaNo;
        BrgId = brgId;
        Satuan = satuan;
        KonversiSatuan = konversiSatuan;
        Qty = qty;
        HargaJual = hargaJual;
    }
    public string FakturId { get; set; }
    public string FakturItemId { get; set; }
    public string FakturStokHargaId { get; set; }
    public int ItemNo { get; set; }
    public int QtyHargaNo { get; set; }
    
    public string BrgId { get; set; }
    public string Satuan { get; set; }
    public int KonversiSatuan { get; set; } 
    public int Qty { get; set; }
    public double HargaJual { get; set; }
}