using btr.application.Helpers;
using btr.application.SalesContext.FakturAgg.Contracts;
using Dawn;
using MediatR;
using Nuna.Lib.ValidationHelper;

namespace btr.application.SalesContext.FakturAgg.UseCases;

public record ListFakturQuery(string Tgl1, string Tgl2)
    : IRequest<IEnumerable<ListFakturResponse>>;

public class ListFakturResponse
{
    public string FakturId { get; set; }
    public string FakturDate { get; set; }
    public string CustomerName { get; set; }
}

public class ListFakturHandler : IRequestHandler<ListFakturQuery, IEnumerable<ListFakturResponse>>
{
    private readonly IFakturDal _fakturDal;

    public ListFakturHandler(IFakturDal fakturDal)
    {
        _fakturDal = fakturDal;
    }

    public Task<IEnumerable<ListFakturResponse>> Handle(ListFakturQuery request, CancellationToken cancellationToken)
    {
        //  GUARD
        Guard.Argument(() => request)
            .Member(x => x.Tgl1, y => y.ValidDate("yyyy-MM-dd"))
            .Member(x => x.Tgl2, y => y.ValidDate("yyyy-MM-dd"));
        
        //  QUERY
        var periode = new Periode(
            request.Tgl1.ToDate(DateFormatEnum.YMD),
            request.Tgl2.ToDate(DateFormatEnum.YMD));
        var result = _fakturDal.ListData(periode)
            ?? throw new KeyNotFoundException("Faktur not found");
        
        //  RESPONSE
        var response =
            from c in result
            select new ListFakturResponse
            {
                FakturId = c.FakturId,
                FakturDate = c.FakturDate.ToString("yyyy-MM-dd"),
                CustomerName = c.CustomerName
            };
        return Task.FromResult(response);
    }
}
