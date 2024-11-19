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
    public async Task<ResponseDto<None>> SellerMaquinaAsync(FindOneMaquinaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(SellerMaquinaAsync));
        try
        {
            var maquina = await _repository.GetByIdAsync(request.IdMaquina, cancellationToken);

            maquina.Vendida = !maquina.Vendida;
            maquina.Status = 0;
            maquina.DataAtualizacao = DateTime.Now;
            
            await _repository.UpdateAsync(maquina, cancellationToken,
                m => m.Vendida,
                m => m.Status,
                m => m.DataAtualizacao);
            await _repository.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Vendida com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(SellerMaquinaAsync));
        }
    }
}