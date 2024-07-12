using MediatR;
using MicroErp.Application.UserCases.User.ActiveUser;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.DeleteUser;

public class DeleteUserHandle: IRequestHandler<DeleteUserRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public DeleteUserHandle(IUserService userService) => _userService = userService;
    
    public async Task<ResponseDto<None>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        return await _userService.DeleteUserAsync(request, cancellationToken);
    }
}