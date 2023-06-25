using btr.domain.SalesContext.FakturAgg;
using btr.infrastructure.SalesContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.SalesContext;

public class FakturItemDalTest
{
    private readonly FakturItemDal _sut;

    public FakturItemDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new FakturItemDal(opt);
    }

    private static FakturItemModel Faker() =>
        new FakturItemModel
        {
            FakturId = "A",
            FakturItemId = "B",
            NoUrut = 1,
            BrgId = "C",
            BrgName = "",
            AvailableQty = 2,
            Qty = 3,
            HargaJual = 4,
            SubTotal = 5,
            DiscountRp = 6,
            PpnProsen = 7,
            PpnRp = 8,
            Total = 9,            
        };
    
    [Fact]
    public void InsertTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturItemModel>{Faker()});
    }

    [Fact]
    public void DeleteTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturItemModel>{Faker()});
        _sut.Delete(Faker());
    }

    [Fact]
    public void ListDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturItemModel>{Faker()});
        var actual = _sut.ListData(Faker());
        actual.Should().BeEquivalentTo(new List<FakturItemModel>{Faker()});
    }
}