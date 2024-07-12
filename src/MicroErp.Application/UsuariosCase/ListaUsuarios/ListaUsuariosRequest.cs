using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;

namespace MicroErp.Application.UsuariosCase.ListaUsuarios;

public class ListaUsuariosRequest: ListaUsuariosRequestDto, IRequest<ResponseDto<IEnumerable<ListaUsuariosResponseDto>>>
{
    
}