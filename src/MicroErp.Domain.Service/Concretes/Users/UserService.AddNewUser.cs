using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Email;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> AddNewUserAsync(AddNewUserRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddNewUserAsync));
        try
        {
            var result = await _userManager.FindByEmailAsync(request.Email);
            if (result != null)
            {
                return ResponseDto.Fail("Usuário já cadastrado", HttpStatusCode.BadRequest);
            }

            if (request.Password != request.ConfirmPassword)
            {
                return ResponseDto.Fail("Verifique a senha.", HttpStatusCode.BadRequest);
            }

            var entityUser = _mapper.Map<User>(request); 
            
            var resultCreate = await _userManager.CreateAsync(new User(entityUser.Nome, entityUser.Email, true) , request.Password);
            if (!resultCreate.Succeeded)
            {
                return ResponseDto.Fail($"Falha ao cadastrar usuário:{resultCreate.Errors.FirstOrDefault()}", HttpStatusCode.BadRequest);
            }
           
            return ResponseDto.Sucess("Cadastrado com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddNewUserAsync));
        }
    }
}
