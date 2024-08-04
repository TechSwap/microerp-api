using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService
{
    public async Task<ResponseDto<FindOneUserResponseDto>> FindOneUserAsync(FindOneUserRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneUserAsync));

        var user = await _userManager.FindByIdAsync(requestDto.Id);

        if (user == null)
        {
            return ResponseDto<FindOneUserResponseDto>.Fail(HttpStatusCode.NotFound);
        }

        var departamento = await _repositoryDepartamento.GetByIdAsync(user.IdDepartamento, cancellationToken);
        
        var data = new FindOneUserResponseDto
        {
            UserId = user.Id,
            Email = user.Email,
            Nome  = user.Nome,
            IdDepartamento = user.IdDepartamento,
            Departamento = departamento?.Descricao,
            Ativo = user.AtivoUsuario
        };
        
        logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneUserAsync));
        return ResponseDto<FindOneUserResponseDto>.Sucess(data);
    }
}