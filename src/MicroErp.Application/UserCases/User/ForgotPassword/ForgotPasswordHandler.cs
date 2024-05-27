using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ForgotPassword;

public class ForgotPasswordHandler : IRequestHandler<ForgotPasswordRequest, ResponseDto<None>>
{
    private readonly IUserService _userService;

    public ForgotPasswordHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<ResponseDto<None>> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
    {
        return _userService.ForgotPasswordAsync(request, cancellationToken);
    }
}
