using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.OrdemProducaoCases.AddOrdem;
using MicroErp.Application.OrdemProducaoCases.FindOneOrdem;
using MicroErp.Application.OrdemProducaoCases.ListOrdens;
using MicroErp.Application.OrdemProducaoCases.PrintOrdem;
using MicroErp.Application.OrdemProducaoCases.StartOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;
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
    
    [HttpGet("find-one")]
    [ProducesResponseType(typeof(ResponseDto<FindOneOdermProducaoResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FindOneOP([FromQuery] FindOneOrdemProducaoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("start-op")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> StartOpAsync([FromBody] StartOrdemProducaoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-Ops")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllOps([FromQuery] ListOrdensProducaoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("print-form")]
    [ProducesResponseType(typeof(ResponseDto<FindOneOdermProducaoResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PrintFromAsync([FromForm] PrintOrdemProducaoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}