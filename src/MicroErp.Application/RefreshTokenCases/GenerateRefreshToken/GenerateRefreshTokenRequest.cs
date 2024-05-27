using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Token.SecurityToken;
using MicroErp.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.RefreshTokenCases.GenerateRefreshToken
{
    public class GenerateRefreshTokenRequest : SecurityTokenRequestDto, IRequest<ResponseDto<UserLoginResponseDto>>
    {
    }
}
