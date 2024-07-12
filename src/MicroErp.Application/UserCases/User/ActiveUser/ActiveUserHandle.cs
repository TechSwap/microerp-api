using MediatR;
using MicroErp.Application.UserCases.User.FindOneUser;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ActiveUser;

public class ActiveUserHandle: IRequestHandler<ActiveUserRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public ActiveUserHandle(IUserService userService) => _userService = userService;
    
    public async Task<ResponseDto<None>> Handle(ActiveUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.ActiveUserAsync(request, cancellationToken);
    }
}