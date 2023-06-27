using btr.application.SalesContext.FakturAgg.UseCases;
using btr.application.SalesContext.SalesPersonAgg.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btr.api.Controllers.SalesContext;

[Route("api/[controller]")]
[ApiController]
public class FakturController : ControllerBase
{
    private readonly IMediator _mediator;

    public FakturController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFaktur(CreateFakturCommand cmd)
    {
        var result = await _mediator.Send(cmd);
        return Ok(new JSendOk(result));
    }
    
    [HttpGet]
    [Route("List/{tgl1}/{tgl2}")]
    public async Task<IActionResult> CreateFaktur(string tgl1, string tgl2)
    {
        var query = new ListFakturQuery(tgl1, tgl2);
        var result = await _mediator.Send(query);
        return Ok(new JSendOk(result));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> CreateFaktur(string id)
    {
        var query = new GetFakturQuery(id);
        var result = await _mediator.Send(query);
        return Ok(new JSendOk(result));
    }
}