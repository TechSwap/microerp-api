using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService
{
    public async Task<ResponseDto<FindOneOrdemResponseDto>> FindOneOrdemAsync(FindOneOrdemRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneOrdemAsync));
        try
        {
            var ordem = await _repositoryOrdemServico.GetByOneAsync(o => o.Id == request.IdOrdemServico, cancellationToken,
                o => o.DetalhesOrdemServico,
                o => o.Cliente);

            var detalhes = ordem.DetalhesOrdemServico;

            if (ordem == null)
            {
                return ResponseDto<FindOneOrdemResponseDto>.Fail("Ördem nao cadastrada", HttpStatusCode.BadRequest);
            }

            var cliente = ordem.Cliente;

            var order = new FindOneOrdemResponseDto();
         
            order.IdOrdemServico = ordem.Id;
            order.NumeroOS = ordem.NumeroOS;
            order.IdCliente = ordem.IdCliente;
            order.Cliente = cliente.Nome;
            order.Solicitante = ordem.Solicitante;
            order.NotaSaida = ordem.NotaSaida;
            order.NotaEntrada = ordem.NotaEntrada;
            order.Pedido = ordem.Pedido;
            order.Orcamento = ordem.Orcamento;
            order.ValorTotal = (decimal)ordem.ValorTotal;
            order.Prazo = (int)ordem.Prazo;
            order.Lancamento = ordem.DataCadastro;
            order.DataPrevisaoEntrega = (DateTime)ordem.DataPrevisaoEntrega;
            order.DataEntrega = ordem.DataEntrega == null ? DateTime.MinValue : (DateTime)ordem.DataEntrega;
            
            var details = new List<DetalheOrdemServico>();

            if (detalhes.Count > 0)
            {
                foreach (var detail in detalhes)
                {
                    var itm = new DetalheOrdemServico
                    {
                        IdDetalhesOrdemServico = detail.Id,
                        OrdemServicoId = detail.OrdemServicoId,
                        Descricao = detail.Descricao,
                        ValorUnitario = detail.ValorUnitario,
                        Quantidade = detail.Quantidade,
                        Unidade = detail.Unidade
                    };

                    details.Add(itm);
                }
            }

            order.DetalheOrdemServicos = details;
           
            return ResponseDto<FindOneOrdemResponseDto>.Sucess(order);
        }
        catch (Exception e)
        {
            _unitOfWork.Rollback(cancellationToken);
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<FindOneOrdemResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneOrdemAsync));
        }
    }
}