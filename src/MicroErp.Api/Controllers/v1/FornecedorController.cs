using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.ClienteCases.DeleteCliente;
using MicroErp.Application.FornecedorCases.ActiveFornecedor;
using MicroErp.Application.FornecedorCases.AddFornecedor;
using MicroErp.Application.FornecedorCases.FindOneFornecedor;
using MicroErp.Application.FornecedorCases.ListFornecedores;
using MicroErp.Application.FornecedorCases.UpdateFornecedor;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class FornecedorController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public FornecedorController(IMediator mediator) => _mediator = mediator;
   
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostFornecedor([FromBody] AddFornecedorRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-fornecedores")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListFornecedoresResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllFornecedores([FromQuery] ListFornecedoresRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet()]
    [ProducesResponseType(typeof(ResponseDto<FindOneResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOneFornecedor([FromQuery] FindOneFornecedorRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateFornecedor([FromBody] UpdateFornecedorRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpDelete()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFornecedor([FromQuery] DeleteClienteRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("active-fornecedor")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActiveFornecedor([FromQuery] ActiveFornecedorRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }

}