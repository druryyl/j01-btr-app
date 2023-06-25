using btr.domain.SalesContext.CustomerAgg;
using btr.infrastructure.SalesContext.CustomerAgg;
using btr.test.Helpers;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Nuna.Lib.TransactionHelper;

namespace btr.test.Infrastructure.SalesContext;

public class CustomerDalTest
{
    private readonly CustomerDal _sut;

    public CustomerDalTest()
    {
        var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
        _sut = new CustomerDal(opt);
    }

    private static CustomerModel Faker() =>
        new CustomerModel
        {
            CustomerId = "A",
            CustomerName = "B",
            Plafond = 5250000,
            CreditBalance = 2750000
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
        actual.Should().BeEquivalentTo(new List<CustomerModel>{Faker()});
    }
}