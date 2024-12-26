using System.Net;
using MicroErp.Domain.Entity.OrdemProducao;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial class OrdemProducaoService
{
    public async Task<ResponseDto<None>> StartOrdemAsync(FindOneOrdemProducaoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemProducao.GetByIdAsync(request.IdOrdemProducao, cancellationToken);
            
            var detalhes =  await _repositoryDetalhesOrdemProducao.GetByAsync(d => d.IdOrdemProducao == ordem.Id, cancellationToken);
           
            int status = await GetStatus(request.Detalhes, detalhes.ToList());
            
            ordem.Status = status;
            ordem.DataAtualizacao = DateTime.Now;

            await _repositoryOrdemProducao.UpdateAsync(ordem, cancellationToken,
                o => o.Status,
                o => o.DataAtualizacao);
            await _repositoryOrdemProducao.SaveChangeAsync(cancellationToken);

            foreach (var detalheId in request.Detalhes)
            {
                var detalhe = await _repositoryDetalhesOrdemProducao.GetByIdAsync(detalheId?.IdOrdemProducaoDetalhe, cancellationToken);
              
                detalhe.DataInicializacao = DateTime.Now;
                detalhe.Status = status;

                await _repositoryDetalhesOrdemProducao.UpdateAsync(detalhe, cancellationToken,
                    d => d.Status,
                    d => d.DataInicializacao);
                await _repositoryDetalhesOrdemProducao.SaveChangeAsync(cancellationToken);
            }

            await _ordemServicoService.UpdateStatusOrdemAsync(ordem?.IdOrdemServico, status, cancellationToken);
           
            return ResponseDto.Sucess("Iniciado com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneOrdemAsync));
        }
    }
   
}