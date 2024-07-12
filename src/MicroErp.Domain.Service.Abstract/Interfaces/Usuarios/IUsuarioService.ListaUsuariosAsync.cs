using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Usuarios;

public interface IUsuarioService
{
    Task<ResponseDto<IEnumerable<ListaUsuariosResponseDto>>> ListaUsuariosAsync(ListaUsuariosRequestDto request, CancellationToken cancellationToken);
}