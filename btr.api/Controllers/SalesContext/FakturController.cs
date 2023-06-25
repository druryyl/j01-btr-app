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
    
}