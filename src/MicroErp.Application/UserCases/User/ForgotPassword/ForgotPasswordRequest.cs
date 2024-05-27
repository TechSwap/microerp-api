
using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.ForgotPassword;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ForgotPassword;

public class ForgotPasswordRequest : ForgotPasswordRequestDto, IRequest<ResponseDto<None>>
{
}
