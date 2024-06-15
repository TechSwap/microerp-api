using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.ClienteCases.ActiveCliente;
using MicroErp.Application.ClienteCases.AddCliente;
using MicroErp.Application.ClienteCases.DeleteCliente;
using MicroErp.Application.ClienteCases.FindOneCliente;
using MicroErp.Application.ClienteCases.ListClientes;
using MicroErp.Application.ClienteCases.UpdateCliente;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class ClienteController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostCliente([FromBody] AddClienteRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-clientes")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListClientesResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllClientes([FromQuery] ListClientesRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet()]
    [ProducesResponseType(typeof(ResponseDto<FindOneResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneCliente([FromQuery] FindOneClienteRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCliente([FromBody] UpdateClienteRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpDelete()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCliente([FromQuery] DeleteClienteRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("active")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActiveCliente([FromQuery] ActiveClienteRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}