using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.DepartamentoCases.ActiveDepartamento;
using MicroErp.Application.DepartamentoCases.AddDepartamento;
using MicroErp.Application.DepartamentoCases.FindOneDepartamento;
using MicroErp.Application.DepartamentoCases.ListDepartamentos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.ListDepartamentos;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class DepartamentoController: ApiControllerBase
{
    private readonly IMediator _mediator;
    public DepartamentoController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostDepartamento([FromBody] AddDepartamentoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet()]
    [ProducesResponseType(typeof(ResponseDto<FindOneDepartamentoResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneDepartamento([FromQuery] FindOneDepartamentoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-departamentos")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListDepartamentosResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllDepartamentos([FromQuery] ListDepartamentosRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("active-departamento")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActiveDepartamento([FromQuery] ActiveDepartamentoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    } 
}