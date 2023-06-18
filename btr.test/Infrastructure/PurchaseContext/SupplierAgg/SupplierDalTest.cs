// using btr.domain.PurchaseContext.SupplierAgg;
// using btr.infrastructure.PurchasingContext.SupplierAgg;
// using btr.test.Helpers;
// using FluentAssertions;
// using Microsoft.Extensions.Options;
// using Nuna.Lib.TransactionHelper;
//
// namespace btr.test.Infrastructure.PurchaseContext.SupplierAgg;
//
// public class SupplierDalTest
// {
//     private readonly SupplierDal _sut;
//
//     public SupplierDalTest()
//     {
//         var opt = Options.Create(AppSettingsHelper.GetDatabaseOptions());
//         _sut = new SupplierDal(opt);
//     }
//
//     private SupplierModel Faker() =>
//         new SupplierModel
//         {
//             SupplierId = "A",
//             SupplierName = "B"
//         };
//     
//     [Fact]
//     public void InsertTest()
//     {
//         using var trans = TransHelper.NewScope();
//         _sut.Insert(Faker());
//     }
//
//     [Fact]
//     public void UpdateTest()
//     {
//         using var trans = TransHelper.NewScope();
//         _sut.Update(Faker());
//     }
//
//     [Fact]
//     public void DeleteTest()
//     {
//         using var trans = TransHelper.NewScope();
//         _sut.Insert(Faker());
//         _sut.Delete(Faker());
//     }
//
//     [Fact]
//     public void GetDataTest()
//     {
//         using var trans = TransHelper.NewScope();
//         _sut.Insert(Faker());
//         var actual = _sut.GetData(Faker());
//         actual.Should().BeEquivalentTo(Faker());
//     }
//
//     [Fact]
//     public void ListDataTest()
//     {
//         using var trans = TransHelper.NewScope();
//         _sut.Insert(Faker());
//         var actual = _sut.ListData();
//         actual.Should().BeEquivalentTo(new List<SupplierModel>{Faker()});
//     }
// }