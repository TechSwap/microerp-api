using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.ConfirmEmail;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Users;

public partial interface IUserService
{
	Task<ResponseDto<None>> ConfimEmailAsync(ConfirmEmailRequestDto request, CancellationToken cancellationToken);
}
