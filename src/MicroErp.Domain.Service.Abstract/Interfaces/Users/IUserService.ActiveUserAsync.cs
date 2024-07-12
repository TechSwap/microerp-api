using MicroErp.Domain.Service.Abstract.Interfaces.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService : IBaseService
{
    Task<ResponseDto<None>> ActiveUserAsync(FindOneUserRequestDto request, CancellationToken cancellationToken);
}
