using btr.application.Helpers;
using btr.application.SalesContext.FakturAgg.Workers;
using btr.domain.InventoryContext.BrgAgg;
using btr.domain.InventoryContext.WarehouseAgg;
using btr.domain.SalesContext.FakturAgg;
using btr.domain.SalesContext.OutletAgg;
using btr.domain.SalesContext.SalesPersonAgg;
using btr.domain.SupportContext.UserAgg;
using Dawn;
using Mapster;
using MediatR;
using Nuna.Lib.ValidationHelper;

namespace btr.application.SalesContext.FakturAgg.UseCases;

public record CreateFakturCommand(string FakturDate, string CustomerId,
        string SalesPersonId, string WarehouseId, string RencanaKirimDate,
        int TermOfPayment, string UserId, 
        IEnumerable<CreateFakturCommandItem> ListBrg)
    : IRequest<CreateFakturResponse>, ICustomerKey, 
    ISalesPersonKey, IWarehouseKey, IUserKey;

public record CreateFakturCommandItem(string BrgId, string QtyString, 
    string DiscountString, double PpnProsen)
    : IBrgKey;

public class CreateFakturResponse
{
    public string FakturId { get; set; }
    public string FakturDate { get; set; }
    public string CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string SalesPersonId { get; set; }
    public string SalesPersonName { get; set; }
}

public class CreateFakturHandler : IRequestHandler<CreateFakturCommand, CreateFakturResponse>
{
    private FakturModel _aggRoot = new();
    private readonly IFakturBuilder _builder;
    private readonly IFakturWriter _writer;

    public CreateFakturHandler(IFakturBuilder builder, IFakturWriter writer)
    {
        _builder = builder;
        _writer = writer;
    }

    public Task<CreateFakturResponse> Handle(CreateFakturCommand request, CancellationToken cancellationToken)
    {
        //  GUARD
        Guard.Argument(() => request).NotNull()
            .Member(x => x.FakturDate, y => y.ValidDate("yyyy-MM-dd"))
            .Member(x => x.CustomerId, y => y.NotEmpty())
            .Member(x => x.SalesPersonId, y => y.NotEmpty())
            .Member(x => x.WarehouseId, y => y.NotEmpty());
        
        //  BUILD
        _aggRoot = _builder
            .CreateNew(request)
            .FakturDate(request.FakturDate.ToDate(DateFormatEnum.YMD))
            .Customer(request)
            .SalesPerson(request)
            .Warehouse(request)
            .Build();
        foreach (var item in request.ListBrg)
        {
            _aggRoot = _builder
                .Attach(_aggRoot)
                .AddItem(item, item.QtyString, item.DiscountString, item.PpnProsen)
                .Build();
        }
        
        //  APPLY
        _writer.Save(ref _aggRoot);
        return Task.FromResult(GenResponse());
    }

    private CreateFakturResponse GenResponse()
    {
        var result = _aggRoot.Adapt<CreateFakturResponse>();
        return result;
    }
}
