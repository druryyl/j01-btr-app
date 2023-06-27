using btr.domain.InventoryContext.BrgAgg;
using btr.domain.InventoryContext.StokAgg;
using btr.infrastructure.InventoryContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.InventoryContext;

public class StokMutasiDalTest
{
    private readonly StokMutasiDal _sut;

    public StokMutasiDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new StokMutasiDal(opt);
    }

    private static StokMutasiModel Faker() =>
        new StokMutasiModel
        {
            StokId = "A", 
            StokMutasiId = "B", 
            MutasiId = "V", 
            NoUrut = 1, 
            MutasiDate = new DateTime(2023,2,3), 
            QtyIn = 2, 
            QtyOut = 3, 
            HargaJual = 4, 
        };
    
    [Fact]
    public void InsertTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<StokMutasiModel>{Faker()});
    }

    [Fact]
    public void DeleteTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<StokMutasiModel>{Faker()});
        _sut.Delete(Faker());
    }

    [Fact]
    public void ListDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<StokMutasiModel>{Faker()});
        var actual = _sut.ListData(Faker());
        actual.Should().BeEquivalentTo(new List<StokMutasiModel>{Faker()});
    }
}