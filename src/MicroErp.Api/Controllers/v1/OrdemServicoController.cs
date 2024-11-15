using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.OrdemServicoCases.AddOrdem;
using MicroErp.Application.OrdemServicoCases.FindOneOrdem;
using MicroErp.Application.OrdemServicoCases.GetNumeroOS;
using MicroErp.Application.OrdemServicoCases.ListOrdens;
using MicroErp.Application.OrdemServicoCases.Relatorio;
using MicroErp.Application.OrdemServicoCases.UpdateOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.GetNumeroOS;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.Relatorio;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class OrdemServicoController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public OrdemServicoController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("novaOS")]
    [ProducesResponseType(typeof(ResponseDto<GetNumeroOSResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNumeroOs([FromQuery]GetNumeroOSRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PostOrdemServico([FromBody] AddOrdemRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("find-one")]
    [ProducesResponseType(typeof(ResponseDto<FindOneOrdemResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FindOneOS([FromQuery] FindOneOrdemRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOrdemServico([FromBody] UpdateOrdemRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("lista-Os")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListOrdensResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllOs([FromQuery] ListOrdensRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    
    [HttpGet("relatorio")]
    [ProducesResponseType(typeof(ResponseDto<RelatorioExcelResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllOs([FromQuery] RelatorioExcelRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}