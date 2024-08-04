using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;

public class ListaUsuariosRequestDto: RequestPaginatedDto
{
    public string Nome { get; set; }
    public string Email { get; set; }
}