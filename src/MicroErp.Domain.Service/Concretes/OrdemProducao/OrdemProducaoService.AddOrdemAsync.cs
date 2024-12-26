using System.Net;
using MicroErp.Application.OrdemServicoCases.FindOneOrdem;
using MicroErp.Domain.Entity.OrdemProducao;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.AddOrdem;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial class OrdemProducaoService
{
    public async Task<ResponseDto<None>> AddOrdemAsync(AddOrdemRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddOrdemAsync));
        try
        {
            var ordens = await _repositoryOrdemProducao.GetByAsync(o => o.Id != null, cancellationToken);

            var lastOrder = ordens.OrderByDescending(o => o.NumeroOp).Select(o => o.NumeroOp).FirstOrDefault();
            var prazo = DateTime.Now;

            string IdOrdemServico = string.Empty;

            if (!string.IsNullOrEmpty(request.IdOrdemServico))
            {
                var Os =  await _ordemServicoService.FindOneOrdemAsync(new FindOneOrdemRequest { IdOrdemServico = request.IdOrdemServico }, cancellationToken);

                IdOrdemServico = Os.Data.IdOrdemServico;
                prazo = (DateTime)Os.Data.DataPrevisaoEntrega;
            }
            else
            {
                prazo.AddDays(request.Prazo);
            }
            
            var novaOp = new Entity.OrdemProducao.OrdemProducao
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                NumeroOp = lastOrder + 1,
                IdCliente = request.IdCliente,
                IdOrdemServico = request.IdOrdemServico,
                Prazo = request.Prazo,
                Status = 1,
                DataCadastro = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await _repositoryOrdemProducao.InsertAsync(novaOp, cancellationToken);
            await _repositoryOrdemProducao.SaveChangeAsync(cancellationToken);

            foreach (var detalhe in request.Detalhes)
            {
                var det = new DetalhesOrdemProducao
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    IdOrdemProducao = novaOp.Id,
                    Descricao = detalhe.Descricao,
                    Quantidade = detalhe.Quantidade,
                    Unidade = detalhe.Unidade,
                    PrazoEntrega = prazo
                };

                await _repositoryDetalhesOrdemProducao.InsertAsync(det, cancellationToken);
                await _repositoryDetalhesOrdemProducao.SaveChangeAsync(cancellationToken);

                await _ordemServicoService.UpdateStatusDetailOrdemAsync(det.Id, 1, cancellationToken);
            }

            await _ordemServicoService.UpdateStatusOrdemAsync(IdOrdemServico, 1, cancellationToken);
            
            return ResponseDto.Sucess("Ordem gerada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddOrdemAsync));
        }
    }
}