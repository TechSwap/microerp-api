using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ConfirmEmail;

public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailRequest, ResponseDto<None>>
{
	private readonly IUserService _userService;

	public ConfirmEmailHandler(IUserService userService)
	{
		_userService = userService;
	}

	public Task<ResponseDto<None>> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
	{
		return _userService.ConfimEmailAsync(request, cancellationToken);
	}
}
