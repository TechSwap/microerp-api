using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.UsuariosCase.ListaUsuarios;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

public class UsuarioController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator) => _mediator = mediator;
    
    [HttpGet("lista-usuarios")]
    [ProducesResponseType(typeof(ResponseDto<IEnumerable<ListaUsuariosResponseDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllUsuarios([FromQuery] ListaUsuariosRequest request)
    {
        var response = await _mediator.Send(request);
        return CreateResult(response);
    }
}