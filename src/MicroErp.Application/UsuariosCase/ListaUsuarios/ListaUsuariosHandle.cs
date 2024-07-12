using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;
using MicroErp.Domain.Service.Abstract.Interfaces.Usuarios;

namespace MicroErp.Application.UsuariosCase.ListaUsuarios;

public class ListaUsuariosHandle: IRequestHandler<ListaUsuariosRequest, ResponseDto<IEnumerable<ListaUsuariosResponseDto>>>
{
    private readonly IUsuarioService _usuarioService;

    public ListaUsuariosHandle(IUsuarioService usuarioService) => _usuarioService = usuarioService;
    
    public Task<ResponseDto<IEnumerable<ListaUsuariosResponseDto>>> Handle(ListaUsuariosRequest request, CancellationToken cancellationToken)
    {
        return _usuarioService.ListaUsuariosAsync(request, cancellationToken);
    }
}