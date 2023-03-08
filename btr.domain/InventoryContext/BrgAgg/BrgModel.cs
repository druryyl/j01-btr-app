using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btr.domain.InventoryContext.BrgAgg;

public class BrgModel
{
    public string BrgId { get; set; }
    public string BrgName { get; set;}
    public IEnumerable<BrgSatuanModel> ListSatuan { get; set; }
}
