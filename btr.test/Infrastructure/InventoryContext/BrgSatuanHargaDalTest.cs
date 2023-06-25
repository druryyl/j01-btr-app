using btr.domain.InventoryContext.BrgAgg;
using btr.infrastructure.InventoryContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.InventoryContext;

public class BrgSatuanHargaDalTest
{
    private readonly BrgSatuanHargaDal _sut;

    public BrgSatuanHargaDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new BrgSatuanHargaDal(opt);
    }

    private static BrgSatuanHargaModel Faker() =>
        new BrgSatuanHargaModel
        {
            BrgId = "A",
            Satuan = "B",
            Conversion = 1,
            HargaJual = 2,
        };
    
    [Fact]
    public void InsertTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<BrgSatuanHargaModel>{Faker()});
    }

    [Fact]
    public void DeleteTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<BrgSatuanHargaModel>{Faker()});
        _sut.Delete(Faker());
    }

    [Fact]
    public void ListDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<BrgSatuanHargaModel>{Faker()});
        var actual = _sut.ListData(Faker());
        actual.Should().BeEquivalentTo(new List<BrgSatuanHargaModel>{Faker()});
    }
}