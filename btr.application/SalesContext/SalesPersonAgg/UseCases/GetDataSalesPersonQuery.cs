using btr.application.SalesContext.SalesPersonAgg.Workers;
using btr.domain.SalesContext.SalesPersonAgg;
using Dawn;
using Mapster;
using MediatR;

namespace btr.application.SalesContext.SalesPersonAgg.UseCases;

public record GetDataSalesPersonQuery(string SalesPersonId) 
    : IRequest<GetDataSalesPersonResponse>, ISalesPersonKey;

public class GetDataSalesPersonResponse
{
    public string SalesPersonId { get; set; }
    public string SalesPersonName { get; set; }
}

public class GetDataSalesPersonHandler : IRequestHandler<GetDataSalesPersonQuery, GetDataSalesPersonResponse>
{
    private SalesPersonModel _aggRoot = new();
    private readonly ISalesPersonBuilder _builder;

    public GetDataSalesPersonHandler(ISalesPersonBuilder builder)
    {
        _builder = builder;
    }

    public Task<GetDataSalesPersonResponse> Handle(GetDataSalesPersonQuery request, CancellationToken cancellationToken)
    {
        //  GUARD
        Guard.Argument(() => request).NotNull()
            .Member(x => x.SalesPersonId, y => y.NotEmpty());
        
        //  BUILD
        _aggRoot = _builder
            .Load(request)
            .Build();
        
        //  APPLY
        return Task.FromResult(GenResponse());
    }
    
    private GetDataSalesPersonResponse GenResponse()
    {
        var result = _aggRoot.Adapt<GetDataSalesPersonResponse>();
        return result;
    }
}