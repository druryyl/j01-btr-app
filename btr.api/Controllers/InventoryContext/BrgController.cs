using btr.application.InventoryContext.BrgAgg.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btr.api.Controllers.InventoryContext;

[Route("api/[controller]")]
[ApiController]
public class BrgController : Controller
{
    private readonly IMediator _mediator;

    public BrgController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id}")]   
    public async Task<IActionResult> GetBrgHarga(string id)
    {
        var query = new GetBrgHargaQuery(id);
        var result = await _mediator.Send(query);
        return Ok(new JSendOk(result));
    }
}