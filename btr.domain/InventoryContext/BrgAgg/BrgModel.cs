using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.domain.InventoryContext.BrgAgg;

public class BrgModel : IBrgKey
{
    public string BrgId { get; set; }
    public string BrgName { get; set;}
    public List<BrgSatuanModel> ListSatuan { get; set; }
    public List<BrgHargaJualModel> ListHarga { get; set; }
}


public class BrgHargaJualModel
{
    public string BrgId { get; set; }
    public string Satuan { get; set; }
    public double HargaJual { get; set; }
}

public interface IBrgKey
{
    string BrgId { get; }
}
