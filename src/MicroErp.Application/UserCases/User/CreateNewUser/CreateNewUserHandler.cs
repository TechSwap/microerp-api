using MediatR;
using MicroErp.Application.UserCases.User.CreateNewUser;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.Users.CreateNewUser;

public class CreateNewUserHandler : IRequestHandler<CreateNewUserRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public CreateNewUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ResponseDto<None>> Handle(CreateNewUserRequest request, CancellationToken cancellationToken)   
    {
        return await _userService.AddNewUserAsync(request, cancellationToken);
    }
}