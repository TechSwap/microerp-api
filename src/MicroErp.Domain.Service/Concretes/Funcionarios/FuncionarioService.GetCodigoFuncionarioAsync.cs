using System.Net;
using MicroErp.Domain.Entity.Funcionarios;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.GetCodigoFuncionario;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService
{
    public async Task<ResponseDto<GetCodigoFuncionarioResponseDto>> GetCodigoFuncionarioAsync(GetCodigoFuncionarioRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(GetCodigoFuncionarioAsync));
        try
        {
            var funcionarios = await _repository.GetByAsync(f => f.Id != null, cancellationToken);

            int lastCodigo = funcionarios.OrderBy(f => f.Codigo).Select(f => f.Codigo).LastOrDefault();

            var response = new GetCodigoFuncionarioResponseDto
            {
                Codigo = lastCodigo + 1,
            };
            
            return ResponseDto<GetCodigoFuncionarioResponseDto>.Sucess(response);
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<GetCodigoFuncionarioResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(GetCodigoFuncionarioAsync));
        }
    }
}