using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.ResetPassword;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ResetPassword;

public class ResetPasswordRequest : ResetPasswordRequestDto, IRequest<ResponseDto<None>>
{
}


