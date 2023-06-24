using btr.domain.InventoryContext.BrgAgg;

namespace btr.domain.SalesContext.FakturAgg;

public class FakturStokHargaModel : IFakturKey, 
    IFakturItemKey, IFakturStokHargaKey, IBrgKey
{
    public string FakturId { get; set; }
    public string FakturItemId { get; set; }
    public string FakturStokHargaId { get; set; }
    public int ItemNo { get; set; }
    public int StokHargaNo { get; set; }
    
    public string BrgId { get; set; }
    public string Satuan { get; set; }
    public int KonversiSatuan { get; set; } 
    public string Stok { get; set; }
    public string HargaJual { get; set; }
}