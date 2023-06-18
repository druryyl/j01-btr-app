using btr.application.SalesContext.SalesPersonAgg.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btr.api.Controllers.SalesContext;

[Route("api/[controller]")]
[ApiController]
public class SalesPersonController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesPersonController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetSalesPerson(string id)
    {
        var query = new GetDataSalesPersonQuery(id);
        var result = await _mediator.Send(query);
        return Ok(new JSendOk(result));
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> ListDataSalesPerson()
    {
        var query = new ListDataSalesPersonQuery();
        var result = await _mediator.Send(query);
        return Ok(new JSendOk(result));
    }

    [HttpPost]
    public async Task<IActionResult> CreateSalesPerson(CreateSalesPersonCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(new JSendOk(result));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSalesPerson(UpdateSalesPersonCommand command)
    {
        await _mediator.Send(command);
        return Ok(new JSendOk("Ok"));
    }
}