using btr.domain.InventoryContext.BrgAgg;
using btr.infrastructure.InventoryContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.InventoryContext;

public class BrgDalTest
{
    private readonly BrgDal _sut;

    public BrgDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new BrgDal(opt);
    }

    private static BrgModel Faker() =>
        new BrgModel
        {
            BrgId = "A",
            BrgName = "B",
        };
    
    [Fact]
    public void InsertTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(Faker());
    }

    [Fact]
    public void UpdateTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Update(Faker());
    }

    [Fact]
    public void DeleteTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(Faker());
        _sut.Delete(Faker());
    }

    [Fact]
    public void GetDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(Faker());
        var actual = _sut.GetData(Faker());
        actual.Should().BeEquivalentTo(Faker());
    }

    [Fact]
    public void ListDataTest()
    {
        using var trans = TransHelper.NewScope();
        _sut.Insert(Faker());
        var actual = _sut.ListData();
        actual.Should().BeEquivalentTo(new List<BrgModel>{Faker()});
    }
}