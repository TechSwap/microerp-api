using MicroErp.Domain.Service.Abstract.Interfaces.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService : IBaseService
{
    Task<ResponseDto<FindOneUserResponseDto>> FindOneUserAsync(FindOneUserRequestDto requestDto, CancellationToken cancellationToken = default);
}
