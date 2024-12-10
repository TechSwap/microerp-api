using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial class OrdemProducaoService
{
    public async Task<ResponseDto<FindOneOdermProducaoResponseDto>> FindOneOrdemAsync(FindOneOrdemProducaoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemProducao.GetByIdAsync(request.IdOrdemProducao, cancellationToken);

            var detalhes = await _repositoryDetalhesOrdemProducao.GetByAsync(d => d.IdOrdemProducao == ordem.Id, cancellationToken);
            var cliente = await _repositoryCliente.GetByIdAsync(ordem.IdCliente, cancellationToken);

            var listDetalhes = new List<DetalhesOrdemProducaoResponseDto>();
            foreach (var detalhe in detalhes)
            {
                listDetalhes.Add(new DetalhesOrdemProducaoResponseDto
                {
                    IdDetalhesOrdemProducao = detalhe.Id,
                    IdOrdemProducao = detalhe.IdOrdemProducao,
                    Descricao = detalhe.Descricao,
                    Unidade = detalhe.Unidade,
                    Quantidade = detalhe.Quantidade,
                    PrazoEntrega = (DateTime)detalhe.PrazoEntrega,
                    DataEntrega = detalhe.DataEntrega
                });
            }

            var response = new FindOneOdermProducaoResponseDto
            {
                IdOrdemProducao = ordem.Id,
                IdOrdemServico = ordem.IdOrdemServico,
                IdCliente = ordem.IdCliente,
                Cliente = cliente?.Nome,
                NumeroOp = ordem.NumeroOp,
                Detalhes = listDetalhes,
                Prazo = ordem.Prazo,
                Status = ordem.Status.ToString()
            };
           
            return ResponseDto<FindOneOdermProducaoResponseDto>.Sucess(response);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<FindOneOdermProducaoResponseDto>.Fail(fail);
        }
        finally
        {
            _unitOfWork.CloseTransaction();
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneOrdemAsync));
        }
    }
}