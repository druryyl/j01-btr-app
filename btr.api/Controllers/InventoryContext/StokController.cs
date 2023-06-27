using btr.application.InventoryContext.StokAgg.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nuna.Lib.ActionResultHelper;

namespace btr.api.Controllers.InventoryContext;

[Route("api/[controller]")]
[ApiController]
public class StokController : Controller
{
    private readonly IMediator _mediator;

    public StokController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("List/{brgId}/{warehouseId}")]   
    public async Task<IActionResult> CreateFaktur(string brgId, string warehouseId)
    {
        var query = new ListBrgStokQuery(brgId, warehouseId);
        var result = await _mediator.Send(query);
        return Ok(new JSendOk(result));
    }
}