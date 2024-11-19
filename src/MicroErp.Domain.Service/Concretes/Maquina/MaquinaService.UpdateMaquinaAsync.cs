using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.UpdateMaquina;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService 
{
    public async Task<ResponseDto<None>> UpdateMaquinaAsync(UpdateMaquinaRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateMaquinaAsync));
        try
        {
            var maquina = await _repository.GetByIdAsync(request.IdMaquina, cancellationToken);

            maquina.Descricao = request.Nome;
            maquina.Fabricante = request.Fabricante;
            maquina.NumeroSerie = request.NumeroSerie;
            maquina.AtivoFixo = request.AtivoFixo;
            maquina.IdDepartamento = request.IdDepartamento;
            maquina.Status = maquina.Status;
            maquina.DataAtualizacao = DateTime.Now;
            
            await _repository.UpdateAsync(maquina, cancellationToken,
                m => m.Descricao,
                m => m.Fabricante,
                m => m.NumeroSerie,
                m => m.Vendida,
                m => m.AtivoFixo,
                m => m.IdDepartamento,
                m => m.Status,
                m => m.DataAtualizacao);
            await _repository.SaveChangeAsync(cancellationToken);
            
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateMaquinaAsync));
        }
    }
}