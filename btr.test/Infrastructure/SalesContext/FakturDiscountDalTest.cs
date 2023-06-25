using btr.domain.SalesContext.FakturAgg;
using btr.infrastructure.SalesContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.SalesContext;

public class FakturDiscountDalTest
{
    private readonly FakturDiscountDal _sut;

    public FakturDiscountDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new FakturDiscountDal(opt);
    }

    private static FakturDiscountModel Faker() =>
        new FakturDiscountModel
        {
            FakturId = "A",
            FakturItemId = "D",
            FakturDiscountId = "B",
            NoUrut = 1,
            BrgId = "C",
            DiscountProsen = 2,
            DiscountRp = 3,
        };
    
    [Fact]
    public void InsertTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturDiscountModel>{Faker()});
    }

    [Fact]
    public void DeleteTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturDiscountModel>{Faker()});
        _sut.Delete(Faker());
    }

    [Fact]
    public void ListDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(new List<FakturDiscountModel>{Faker()});
        var actual = _sut.ListData(Faker());
        actual.Should().BeEquivalentTo(new List<FakturDiscountModel>{Faker()});
    }
}