using System.Collections;
using btr.application.SalesContext.SalesPersonAgg.Contracts;
using btr.application.SalesContext.SalesPersonAgg.Workers;
using btr.domain.SalesContext.SalesPersonAgg;
using Dawn;
using Mapster;
using MediatR;

namespace btr.application.SalesContext.SalesPersonAgg.UseCases;

public record ListDataSalesPersonQuery() 
    : IRequest<IEnumerable<ListDataSalesPersonResponse>>;

public class ListDataSalesPersonResponse
{
    public string SalesPersonId { get; set; }
    public string SalesPersonName { get; set; }
}

public class ListDataSalesPersonHandler : IRequestHandler<ListDataSalesPersonQuery,IEnumerable<ListDataSalesPersonResponse>>
{
    private readonly ISalesPersonDal _salesPersonDal;
    public ListDataSalesPersonHandler(ISalesPersonDal salesPersonDal)
    {
        _salesPersonDal = salesPersonDal;
    }

    public Task<IEnumerable<ListDataSalesPersonResponse>> Handle(ListDataSalesPersonQuery request, CancellationToken cancellationToken)
    {
        //  BUILD
        var result = _salesPersonDal.ListData()
            ?? throw new KeyNotFoundException("SalesPerson not found");

        //  APPLY
        return Task.FromResult(GenResponse(result));
    }
    
    private IEnumerable<ListDataSalesPersonResponse>  GenResponse(IEnumerable<SalesPersonModel> listSalesPerson)
    {
        var result = listSalesPerson.Adapt<IEnumerable<ListDataSalesPersonResponse>>();
        return result;
    }
}