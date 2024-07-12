using System.Net;
using MicroErp.Domain.Entity.OrdemCompras;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemCompra;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemCompra;

public partial class OrdemCompraService
{
     public async Task<ResponseDto<None>> AddOrdemCompraAsync(AddOrdemCompraRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddOrdemCompraAsync));
        try
        {
            var pedidos = await _repositoryOrdemCompra.GetByAsync(o => o.Id != null, cancellationToken);
            
            var ultimoPedido = pedidos.OrderBy(o => o.NumeroPedido).Select(o => o.NumeroPedido).LastOrDefault();
            
            long pedido = (ultimoPedido == request.NumeroPedido) ? request.NumeroPedido : ultimoPedido + 1;

            var OC = new Entity.OrdemCompras.OrdemCompra
            {
                Id = Guid.NewGuid().ToString().ToLower(),
            };
            
            await _repositoryOrdemCompra.InsertAsync(OC, cancellationToken);
            await _repositoryOrdemCompra.SaveChangeAsync(cancellationToken);
            
            foreach (var itm in request.Detalhes)
            {
                var detalhe = new DetalhesOrdemCompra
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    IdOrdemCompra = OC.Id,
                   
                };
            
                await _repositoryDetalhesOrdemCompra.InsertAsync(detalhe, cancellationToken);
                await _repositoryDetalhesOrdemCompra.SaveChangeAsync(cancellationToken);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddOrdemCompraAsync));
        }
    }
}