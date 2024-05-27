using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.ProdutoCases.ActiveProduto;
using MicroErp.Application.ProdutoCases.AddProduto;
using MicroErp.Application.ProdutoCases.FindOneProduto;
using MicroErp.Application.ProdutoCases.UpdateProduto;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class ProdutoController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator) => _mediator = mediator;
    
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostProduto([FromBody] AddProdutoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-produtos")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListProdutosResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProdutos([FromQuery] ListProdutosRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("find-one")]
    [ProducesResponseType(typeof(ResponseDto<FindOneProdutoResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FindOneProduto([FromQuery] FindOneProdutoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateProduto([FromBody] UpdateProdutoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost("active")]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ActiveProduto([FromQuery] ActiveProdutoRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}