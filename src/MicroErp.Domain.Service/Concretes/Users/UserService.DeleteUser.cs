using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<None>> DeleteUserAsync(FindOneUserRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(DeleteUserAsync));

        var user = await _userManager.FindByIdAsync(requestDto.Id);

        if (user == null)
            return ResponseDto.Fail(HttpStatusCode.NotFound);
            
        var result  = await _userManager.DeleteAsync(user);
       
        logger.LogInformation("Metodo finalizado:{0}", nameof(DeleteUserAsync));
        return result.Succeeded ? ResponseDto.Sucess("Deletado com sucesso", HttpStatusCode.NoContent) : ResponseDto.Fail(Constants.DefaultFail);
    }
}