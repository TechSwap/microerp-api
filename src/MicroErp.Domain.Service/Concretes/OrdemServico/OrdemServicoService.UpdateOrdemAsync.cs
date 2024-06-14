using System.Net;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.UpdateOrdem;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<None>> UpdateOrdemAsync(UpdateOrdemRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemServico.GetByOneAsync(o => o.Id != request.IdOrdemServico, cancellationToken,
                o => o.DetalhesOrdemServico);

            var detalhes = ordem.DetalhesOrdemServico;

            ordem.Solicitante = request.Solicitante;
            ordem.NotaEntrada = request.NotaEntrada;
            ordem.NotaSaida = request.NotaSaida;
            ordem.Pedido = request.Pedido;
            ordem.Orcamento = request.Orcamento;
            ordem.ValorTotal = request.ValorTotal;
            ordem.Prazo = request.Prazo;
            ordem.DataEntrega = request.DataEntrega;
            ordem.DataPrevisaoEntrega = request.DataPrevisaoEntrega;
          
            await _repositoryOrdemServico.UpdateAsync(ordem, cancellationToken,
                o => o.Solicitante,
                o => o.NotaEntrada,
                o => o.NotaSaida,
                o => o.Pedido,
                o => o.Orcamento,
                o => o.ValorTotal,
                o => o.Prazo,
                o => o.DataEntrega,
                o => o.DataPrevisaoEntrega
                );
            await _repositoryOrdemServico.SaveChangeAsync(cancellationToken);
           
            foreach (var itm in request.Detalhes)
            {                
                var detalhe = detalhes.Where(d => d.Id == itm.IdDetalhesOrdemServico).FirstOrDefault();                               

                if (detalhe == null)
                {
                    var detail = new DetalhesOrdemServico
                    {
                        Id = Guid.NewGuid().ToString().ToLower(),
                        OrdemServicoId = ordem.Id,
                        Descricao = itm.Descricao,
                        Unidade = itm.Unidade,
                        ValorUnitario = itm.ValorUnitario,
                        Quantidade = itm.Quantidade,
                        PrazoEntrega = ordem.DataPrevisaoEntrega
                    };
            
                    await _repositoryDetalhesOrdemServico.InsertAsync(detail, cancellationToken);
                    await _repositoryDetalhesOrdemServico.SaveChangeAsync(cancellationToken);                   
                }
                else
                {
                    detalhe.Descricao = itm.Descricao;
                    detalhe.ValorUnitario = itm.ValorUnitario;
                    detalhe.Quantidade = itm.Quantidade;
                    detalhe.Unidade = itm.Unidade;

                    await _repositoryDetalhesOrdemServico.UpdateAsync(detalhe, cancellationToken);
                    await _repositoryDetalhesOrdemServico.SaveChangeAsync(cancellationToken);
                }
            }
            
            return ResponseDto.Sucess("Ordem atualizada com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateOrdemAsync));
        }
    }
}