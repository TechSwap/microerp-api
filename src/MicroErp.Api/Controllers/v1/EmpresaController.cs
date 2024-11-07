using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.EmpresaCase.GetEmpresa;
using MicroErp.Application.EmpresaCase.UpdateEmpresa;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class EmpresaController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public EmpresaController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet()]
    [ProducesResponseType(typeof(ResponseDto<GetEmpresaResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmpresa([FromQuery] GetEmpresaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
    [HttpPut()]
    [ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateEmpresa([FromBody] UpdateEmpresaRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}