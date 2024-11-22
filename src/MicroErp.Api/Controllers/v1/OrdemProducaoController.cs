using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.OrdemProducaoCases.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class OrdemProducaoController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public OrdemProducaoController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost("novaOP")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostNovaOP([FromBody]AddOrdemProducaoRequest producaoRequest)
    {
        var response = await _mediator.Send(producaoRequest);
        return CreateResult(response);
    }
}