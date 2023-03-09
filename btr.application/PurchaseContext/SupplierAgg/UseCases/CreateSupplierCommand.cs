using btr.application.PurchaseContext.SupplierAgg.Workers;
using btr.domain.PurchaseContext.SupplierAgg;
using Dawn;
using JetBrains.Annotations;
using MediatR;

namespace btr.application.PurchaseContext.SupplierAgg.UseCases;

[PublicAPI]
public record CreateSupplierCommand(string SupplierName) : IRequest<CreateSupplierResponse>;

[PublicAPI]
public class CreateSupplierResponse
{
    public string SupplierId { get; set; }
    public string SupplierName { get; set; }
}

public class CreateSupplierHandler : IRequestHandler<CreateSupplierCommand, CreateSupplierResponse>
{
    private SupplierModel _aggRoot;
    public SupplierModel GetAggRoot() => _aggRoot;
    private readonly ISupplierBuilder _builder;
    private readonly ISupplierWriter _writer;

    public CreateSupplierHandler(ISupplierBuilder builder, 
        ISupplierWriter writer)
    {
        _builder = builder;
        _writer = writer;
    }

    public Task<CreateSupplierResponse> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        //  GUARD
        Guard.Argument(() => request).NotNull()
            .Member(x => x.SupplierName, y => y.NotNull());
        
        //  BUILD
        _aggRoot = _builder
            .CreateNew()
            .Name(request.SupplierName)
            .Build();
        
        //  APPLY
        _writer.Save(ref _aggRoot);
        return Task.FromResult(GenResponse());
    }

    private CreateSupplierResponse GenResponse()
    {
        return new CreateSupplierResponse
        {
            SupplierId = _aggRoot.SupplierId,
            SupplierName = _aggRoot.SupplierName
        };
    }
}

