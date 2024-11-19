using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.MaquinaCases.ActiveMaquina;
using MicroErp.Application.MaquinaCases.AddMaquina;
using MicroErp.Application.MaquinaCases.DeleteMaquina;
using MicroErp.Application.MaquinaCases.FindOneMaquina;
using MicroErp.Application.MaquinaCases.ListMaquinas;
using MicroErp.Application.MaquinaCases.SellerMaquina;
using MicroErp.Application.MaquinaCases.UpdateMaquina;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class MaquinaController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public MaquinaController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostMaquina([FromBody] AddMaquinaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("find-one")]
    [ProducesResponseType(typeof(ResponseDto<FindOneMaquinaResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FindOneMaquina([FromQuery] FindOneMaquinaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateMaquina([FromBody] UpdateMaquinaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }

    
    [HttpGet("lista-maquinas")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListMaquinasResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListMaquinasAsync([FromQuery] ListMaquinasRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("active")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActiveMaquina([FromQuery] ActiveMaquinaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    } 
    
    [HttpPost("sell")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> SellerMaquina([FromQuery] SellerMaquinaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    } 
    
    [HttpDelete("delete")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMaquina([FromQuery] DeleteMaquinaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    } 
}