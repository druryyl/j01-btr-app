using btr.application.InventoryContext.BrgAgg.Workers;
using btr.domain.InventoryContext.BrgAgg;
using Dawn;
using Mapster;
using MediatR;

namespace btr.application.InventoryContext.BrgAgg.UseCases;

public record GetBrgQuery(string BrgId) : IRequest<GetBrgResponse>, IBrgKey;

public class GetBrgResponse
{
    public string BrgId { get; set; }
    public string BrgName { get; set;}
    public List<GetBrgResponseSatuanHrg> ListSatuanHarga { get; set; }
}

public class GetBrgResponseSatuanHrg
{
    public string BrgId { get; set; }
    public string Satuan { get; set; }
    public int Conversion { get; set; }
    public int Stok { get; set; }
    public double HargaJual { get; set; }
}

public class GetBrgHandler : IRequestHandler<GetBrgQuery, GetBrgResponse>
{
    private BrgModel _aggRoot = new();
    private IBrgBuilder _builder;

    public GetBrgHandler(IBrgBuilder builder)
    {
        _builder = builder;
    }

    public Task<GetBrgResponse> Handle(GetBrgQuery request, CancellationToken cancellationToken)
    {
        //  GUARD
        Guard.Argument(() => request)
            .Member(x => x.BrgId, y => y.NotEmpty());
        
        //  QUERY
        _aggRoot = _builder
            .Load(request)
            .Build();
        
        //  RESPONSE
        return Task.FromResult(GenResponse());
    }

    private GetBrgResponse GenResponse()
    {
        var result = _aggRoot.Adapt<GetBrgResponse>();
        return result;
    }
}
