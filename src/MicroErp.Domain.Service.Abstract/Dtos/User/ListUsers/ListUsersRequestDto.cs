using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.ListUsers;
public class ListUsersRequestDto : RequestPaginatedDto
{
    public string Infuencer { get; set; }
    public string Email { get; set; }
    public string CodigoInfluencer { get; set; }
}