using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using System.Net;
using MicroErp.Application.RefreshTokenCases.Token;
using MicroErp.Application.Util;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Token.UserLoginResponse;

namespace MicroErp.Application.RefreshTokenCases.GenerateRefreshToken
{
	public class GenerateRefreshTokenHandler : IRequestHandler<GenerateRefreshTokenRequest, ResponseDto<UserLoginResponseDto>>
	{
		private readonly UserManager<User> _userManager;
		private readonly IJwtService _jwtService;

		public GenerateRefreshTokenHandler(IJwtService jwtService, UserManager<User> userManager)
		{
			_jwtService = jwtService;
			_userManager = userManager;
		}

		public async Task<ResponseDto<UserLoginResponseDto>> Handle(GenerateRefreshTokenRequest request, CancellationToken cancellationToken)
		{
			var handler = new JsonWebTokenHandler();
			var result = handler.ValidateToken(request.RefreshToken, new TokenValidationParameters()
			{
				ValidIssuer = "https://Dev2Y.com.br",
				ValidAudience = "Dev2Y.RefreshToken.API",
				RequireSignedTokens = false,
				IssuerSigningKey = await _jwtService.GetCurrentSecurityKey(),
			});

			if (!result.IsValid)
				return ResponseDto<UserLoginResponseDto>.Fail("Token expirado.", HttpStatusCode.BadRequest);

			var user = await _userManager.FindByEmailAsync(result.Claims[JwtRegisteredClaimNames.Email].ToString());
			
			var claims = await _userManager.GetClaimsAsync(user);

			if (!claims.Any(c => c.Type == "LastRefreshToken" && c.Value == result.Claims[JwtRegisteredClaimNames.Jti].ToString()))
				return ResponseDto<UserLoginResponseDto>.Fail("Token expirado.", HttpStatusCode.BadRequest);

			if (user.LockoutEnabled)
				if (user.LockoutEnd < DateTime.Now)
					return ResponseDto<UserLoginResponseDto>.Fail("Usuário Bloqueado.", HttpStatusCode.BadRequest);

			AccessToken accessToken = new AccessToken();
			RefreshToken refreshToken = new RefreshToken();

			var at = await accessToken.GenerateAccessToken(_userManager, _jwtService, result.Claims[JwtRegisteredClaimNames.Email].ToString());
			var rt = await refreshToken.GenerateRefreshToken(_userManager, _jwtService, result.Claims[JwtRegisteredClaimNames.Email].ToString());

			return ResponseDto<UserLoginResponseDto>.Sucess(new UserLoginResponseDto(at, rt, user.Nome, user.Email, CriptografiaHelper.EncryptQueryString(user.Id),null));

		}
	}
}
