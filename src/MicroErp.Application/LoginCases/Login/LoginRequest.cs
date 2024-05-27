using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;

namespace MicroErp.Application.LoginCases.Login;

public class LoginRequest : UserLoginRequestDto, IRequest<ResponseDto<UserLoginResponseDto>>
{
}
