using btr.domain.SalesContext.FakturAgg;
using btr.infrastructure.SalesContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.SalesContext;

public class FakturQtyHargaDalTest
{
    private readonly FakturQtyHargaDal _sut;

    public FakturQtyHargaDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new FakturQtyHargaDal(opt);
    }

    private static FakturQtyHargaModel Faker() =>
        new FakturQtyHargaModel
        {
            FakturId = "A",
            FakturItemId = "D",
            FakturQtyHargaId = "B",
            NoUrut = 1,
            BrgId = "C",
            Satuan = "C",
            Conversion = 1,
            Qty = 3,
            HargaJual = 4,
        };
    
    [Fact]
    public void InsertTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturQtyHargaModel>{Faker()});
    }

    [Fact]
    public void DeleteTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturQtyHargaModel>{Faker()});
        _sut.Delete(Faker());
    }

    [Fact]
    public void ListDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturQtyHargaModel>{Faker()});
        var actual = _sut.ListData(Faker());
        actual.Should().BeEquivalentTo(new List<FakturQtyHargaModel>{Faker()});
    }
}