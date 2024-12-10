using System.Net;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<None>> UpdateStatusOrdemAsync(string IdOrdemServico,int status, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateStatusOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemServico.GetByIdAsync(IdOrdemServico, cancellationToken);

            ordem.Status = status;
            ordem.DataAtualizacao = DateTime.Now;

            await _repositoryOrdemServico.UpdateAsync(ordem, cancellationToken,
                o => o.Status,
                o => o.DataAtualizacao);
            await _repositoryOrdemServico.SaveChangeAsync(cancellationToken);
            
            return ResponseDto.Sucess("Ordem gerada com sucesso", HttpStatusCode.OK);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateStatusOrdemAsync));
        }
    }
}