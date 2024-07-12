using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> ActiveUserAsync(FindOneUserRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ActiveUserAsync));

        var user = await _userManager.FindByIdAsync(requestDto.Id);

        if (user == null)
            return ResponseDto.Fail(HttpStatusCode.NotFound);
        
        user.AtivoUsuario = !user.AtivoUsuario;
        user.DataAtualizacao = DateTime.Now;
            
        var result  = await _userManager.UpdateAsync(user);
       
        logger.LogInformation("Metodo finalizado:{0}", nameof(ActiveUserAsync));
        return result.Succeeded ? ResponseDto.Sucess("Atualizado com sucesso", HttpStatusCode.NoContent) : ResponseDto.Fail(Constants.DefaultFail);
    }
}