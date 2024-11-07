using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.OrdemCompraCases.AddOrdemCompra;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class OrdemComprasController: ApiControllerBase
{
    private readonly IMediator _mediator;
    public OrdemComprasController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("novaOC")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddOrdemCompraAsync([FromBody]AddOrdemCompraRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}