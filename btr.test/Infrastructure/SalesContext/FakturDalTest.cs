using btr.domain.SalesContext.FakturAgg;
using btr.infrastructure.SalesContext;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;
using Nuna.Lib.ValidationHelper;

namespace btr.test.Infrastructure.SalesContext;

public class FakturDalTest
{
    private readonly FakturDal _sut;

    public FakturDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new FakturDal(opt);
    }

    private static FakturModel Faker() =>
        new FakturModel
        {
            FakturId = "A",
            FakturDate = new DateTime(2023,3,4),
            SalesPersonId = "B",
            SalesPersonName = "",
            CustomerId = "C",
            CustomerName = "",
            Plafond = 0,
            CreditBalance = 0,
            WarehouseId = "D",
            WarehouseName = "",
            TglRencanaKirim =  new DateTime(2023,3,14),
            TermOfPayment = "CRD",
            Total = 3,
            DiscountLain = 4,
            BiayaLain = 5,
            GrandTotal = 6,
            UangMuka = 7,
            KurangBayar = 8,
            CreateTime =  new DateTime(2023,3,5),
            LastUpdate =  new DateTime(2023,3,6),
            UserId = "E"
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
        var actual = _sut.ListData(new Periode(new DateTime(2023,3,4)));
        actual.Should().BeEquivalentTo(new List<FakturModel>{Faker()});
    }
}