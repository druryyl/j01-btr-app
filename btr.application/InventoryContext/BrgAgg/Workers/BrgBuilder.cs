using btr.application.InventoryContext.BrgAgg.Contracts;
using btr.domain.InventoryContext.BrgAgg;
using Nuna.Lib.CleanArchHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.application.InventoryContext.BrgAgg.Workers;

public interface IBrgBuilder : INunaBuilder<BrgModel>
{
    IBrgBuilder Load(IBrgKey brgKey);
}
public class BrgBuilder : IBrgBuilder
{
    private BrgModel _aggRoot = new();
    private readonly IBrgDal _brgDal;
    private readonly IBrgSatuanHargaDal _brgSatuanHargaDal;

    public BrgBuilder(IBrgDal brgDal, 
        IBrgSatuanHargaDal brgSatuanHargaDal)
    {
        _brgDal = brgDal;
        _brgSatuanHargaDal = brgSatuanHargaDal;
    }

    public BrgModel Build()
    {
        _aggRoot.RemoveNull();
        return _aggRoot;
    }

    public IBrgBuilder Load(IBrgKey brgKey)
    {
        _aggRoot = _brgDal.GetData(brgKey)
            ?? throw new KeyNotFoundException($"BrgId not found ({brgKey.BrgId})");
        _aggRoot.ListSatuanHarga = _brgSatuanHargaDal.ListData(brgKey)?.ToList()
            ?? new List<BrgSatuanHargaModel>();
        return this;
    }
}