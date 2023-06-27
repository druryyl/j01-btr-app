using btr.domain.InventoryContext.BrgAgg;
using btr.domain.InventoryContext.StokAgg;
using btr.domain.InventoryContext.WarehouseAgg;
using btr.infrastructure.InventoryContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.InventoryContext;

public class StokDalTest
{
    private readonly StokDal _sut;

    public StokDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new StokDal(opt);
    }

    private static StokModel Faker() =>
        new StokModel
        {
            StokId = "A",
            StokControlId  = "B",
            StokControlDate  = new DateTime(2023,1,2),
            BrgId  = "C",
            BrgName  = "",
            WarehouseId  = "D",
            WarehouseName  = "",
            QtyIn  = 1,
            Qty  = 2,
            NilaiPersediaan  = 3,
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
        var actual = _sut.ListData(new BrgModel("C"), new WarehouseModel("D"));
        actual.Should().BeEquivalentTo(new List<StokModel>{Faker()});
    }
}