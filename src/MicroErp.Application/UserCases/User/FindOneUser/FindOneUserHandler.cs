using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;

namespace MicroErp.Application.UserCases.User.FindOneUser;

public class FindOneUserHandler : IRequestHandler<FindOneUserRequest, ResponseDto<FindOneUserResponseDto>>
{
    private readonly IUserService _userService;
    public FindOneUserHandler(IUserService userService) => _userService = userService;
    public async Task<ResponseDto<FindOneUserResponseDto>> Handle(FindOneUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.FindOneUserAsync(request, cancellationToken);
    }
}