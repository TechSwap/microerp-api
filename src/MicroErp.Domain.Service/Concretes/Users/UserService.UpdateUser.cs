using System.Net;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.UpdateUser;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> UpdateUserAsync(UpdateUserRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateUserAsync));

        try
        {
            User user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
				return ResponseDto.Fail($"Usuário não encontrado", HttpStatusCode.BadRequest);
			}

            user.Nome = request.Nome;
			user.Email = request.Email;
			user.PhoneNumber = request.Celular;
			user.DataInativacao = request.AtivoUsuario?null:DateTime.Now;
			user.AtivoUsuario = request.AtivoUsuario;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return ResponseDto.Fail($"Falha ao atualizar usuário:{result.Errors.FirstOrDefault()}", HttpStatusCode.BadRequest);
            }
            return ResponseDto.Sucess("Atualizado com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateUserAsync));
        }
    }
}
