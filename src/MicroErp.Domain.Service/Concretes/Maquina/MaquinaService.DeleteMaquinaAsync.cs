using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.AddMaquina;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService 
{
    public async Task<ResponseDto<None>> DeleteMaquinaAsync(FindOneMaquinaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(DeleteMaquinaAsync));
        try
        {
            var maquina = await _repository.GetByIdAsync(request.IdMaquina, cancellationToken);
            
            await _repository.DeleteAsync(maquina, cancellationToken);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Deletado com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(DeleteMaquinaAsync));
        }
    }
}