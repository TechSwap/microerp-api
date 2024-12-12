using System.Net;
using MicroErp.Domain.Entity.OrdemProducao;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Enums;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.CancellyOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial class OrdemProducaoService
{
    public async Task<ResponseDto<None>> CancellyOrdemAsync(CancellyOrdemRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(CancellyOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemProducao.GetByIdAsync(request.IdOrdemProducao, cancellationToken);
            
            int status = (int)StatusOP.Cancelada;

            ordem.Status = status;
            ordem.DataCancelamento = DateTime.Now;
            ordem.MotivoCancelamento = request.Motivo;

            await _repositoryOrdemProducao.UpdateAsync(ordem, cancellationToken,
                o => o.Status,
                o => o.DataCancelamento,
                o => o.MotivoCancelamento);
            await _repositoryOrdemProducao.SaveChangeAsync(cancellationToken);
            
            await _ordemServicoService.UpdateStatusOrdemAsync(ordem?.IdOrdemServico, status, cancellationToken);
            
            return ResponseDto.Sucess("Cancelada  com sucesso", HttpStatusCode.NoContent);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto.Fail(fail);
        }
        finally
        {
            _unitOfWork.CloseTransaction();
            logger.LogInformation("Metodo finalizado:{0}", nameof(CancellyOrdemAsync));
        }
    }
   
}