using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.UpdateUser;
using MicroErp.Domain.Service.Abstract.Interfaces.Bases;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService : IBaseService
{
    Task<ResponseDto<None>> UpdateUserAsync(UpdateUserRequestDto request, CancellationToken cancellationToken);
}
