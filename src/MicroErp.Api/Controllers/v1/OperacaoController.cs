using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.OperacaoCases.AddOperacao;
using MicroErp.Application.OperacaoCases.ListOperacoes;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class OperacaoController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public OperacaoController(IMediator mediator) => _mediator = mediator;
   
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostOperacoAsync([FromBody] AddOperacaoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-operacoes")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListOperacoesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllOperacoes([FromQuery] ListOperacoesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}