using System.Net;
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
            var novaOp = new Entity.OrdemProducao.OrdemProducao
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                IdCliente = request.IdCliente,
                IdOrdemServico = request.IdOrdemServico,
                Prazo = request.Prazo,
                Status = 1,
                DataCadastro = DateTime.Now
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
                    PrazoEntrega = (DateTime)detalhe.PrazoEntrega
                };

                await _repositoryDetalhesOrdemProducao.InsertAsync(det, cancellationToken);
                await _repositoryDetalhesOrdemProducao.SaveChangeAsync(cancellationToken);
            }
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