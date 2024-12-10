using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial class OrdemProducaoService
{
    public async Task<ResponseDto<None>> FinallyOrdemAsync(FindOneOrdemProducaoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FinallyOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemProducao.GetByIdAsync(request.IdOrdemProducao, cancellationToken);
            
            var detalhes =  await _repositoryDetalhesOrdemProducao.GetByAsync(d => d.IdOrdemProducao == ordem.Id, cancellationToken);

            int status = 4;

            ordem.Status = status;
            ordem.DataAtualizacao = DateTime.Now;

            await _repositoryOrdemProducao.UpdateAsync(ordem, cancellationToken,
                o => o.Status,
                o => o.DataAtualizacao);
            await _repositoryOrdemProducao.SaveChangeAsync(cancellationToken);

            foreach (var detalheReq in request.Detalhes)
            {
                var detalhe = detalhes.Where(d => d.Id == detalheReq.IdOrdemProducaoDetalhe).FirstOrDefault();
               
                detalhe.IdFuncionario = detalheReq.IdFuncionario;
                detalhe.IdMaquina = detalheReq.IdMaquina;
                detalhe.HorasTrabalhadas = detalheReq.HorasTrabalhadas;
                detalhe.DataFinalizacao = DateTime.Now;
                detalhe.Status = status;

                await _repositoryDetalhesOrdemProducao.UpdateAsync(detalhe, cancellationToken,
                    d =>d.Status,
                    d => d.DataFinalizacao);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(FinallyOrdemAsync));
        }
    }
}