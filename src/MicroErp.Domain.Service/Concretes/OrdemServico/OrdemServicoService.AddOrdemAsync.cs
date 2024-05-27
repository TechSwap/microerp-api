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
    public async Task<ResponseDto<None>> AddOrdemAsync(AddOrdemRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddOrdemAsync));
        try
        {
            var ordens = await _repositoryOrdemServico.GetByAsync(o => o.Id != null, cancellationToken);
                
            var lastOrder = ordens.OrderBy(o => o.NumeroOS).Select(o => o.NumeroOS).LastOrDefault();

            long order = (lastOrder == request.NumeroOs) ? request.NumeroOs : lastOrder + 1;

            var Os = new Entity.OrdemServicos.OrdemServico
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                NumeroOS = order,
                IdCliente = request.IdCliente,
                Solicitante = request.Solicitante,
                NotaEntrada = request.NotaEntrada,
                NotaSaida = request.NotaSaida,
                Pedido = request.Pedido,
                Orcamento = request.Orcamento,
                ValorTotal = request.ValorTotal, 
                Prazo = request.Prazo,
                DataEntrega = request.DataEntrega,
                DataCadastro = request.DataCadastro,
                DataPrevisaoEntrega = request.DataPrevisaoEntrega
            };

            await _repositoryOrdemServico.InsertAsync(Os, cancellationToken);
            await _repositoryOrdemServico.SaveChangeAsync(cancellationToken);
           
            foreach (var itm in request.Detalhes)
            {
                var detalhe = new DetalhesOrdemServico
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    OrdemServicoId = Os.Id,
                    Descricao = itm.Descricao,
                    Unidade = itm.Unidade,
                    ValorUnitario = itm.ValorUnitario,
                    Quantidade = itm.Quantidade,
                    PrazoEntrega = Os.DataPrevisaoEntrega
                };
            
                await _repositoryDetalhesOrdemServico.InsertAsync(detalhe, cancellationToken);
                await _repositoryDetalhesOrdemServico.SaveChangeAsync(cancellationToken);
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