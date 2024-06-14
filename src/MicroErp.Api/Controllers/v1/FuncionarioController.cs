using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.FuncionarioCase.ActiveFuncionario;
using MicroErp.Application.FuncionarioCase.AddFuncionario;
using MicroErp.Application.FuncionarioCase.DeleteFuncionario;
using MicroErp.Application.FuncionarioCase.FindOneFuncionario;
using MicroErp.Application.FuncionarioCase.GetCodigoFuncionario;
using MicroErp.Application.FuncionarioCase.ListFuncionarios;
using MicroErp.Application.FuncionarioCase.UpdateFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.GetCodigoFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class FuncionarioController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public FuncionarioController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostFuncionario([FromBody] AddFuncionarioRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet()]
    [ProducesResponseType(typeof(ResponseDto<FindOneFuncionarioResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneFuncionario([FromQuery] FindOneFuncionarioRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateFuncionario([FromBody] UpdateFuncionarioRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpDelete()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFuncionario([FromQuery] DeleteFuncionarioRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("codigo")]
    [ProducesResponseType(typeof(ResponseDto<GetCodigoFuncionarioResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCodigoFuncionario([FromQuery] GetCodigoFuncionarioRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-funcionarios")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListFuncionariosResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllFuncionarios([FromQuery] ListFuncionariosRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("active")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActiveFuncionario([FromQuery] ActiveFuncionarioRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}