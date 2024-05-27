using System.Net;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.UpdateProduto;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Produtos;

public partial class ProdutoService
{
    public async Task<ResponseDto<None>> UpdateProdutoAsync(UpdateProdutoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(UpdateProdutoAsync));
        try
        {
            var produto = await _repositoryProduto.GetByOneAsync(p => p.Id == request.IdProduto, cancellationToken);

            if (produto == null)
            {
                return ResponseDto.Fail(HttpStatusCode.NotFound);
            }

            produto.Descricao = request.Descricao;
            produto.Unidade = request.Unidade;
            produto.PrecoVenda = request.PrecoVenda;
            produto.PrecoCusto = request.PrecoCusto;
            produto.Observacao = request.Observacao;
            produto.DataAtualizacao = DateTime.Now;
            
            await _repositoryProduto.UpdateAsync(produto, cancellationToken,
                p => p.Descricao,
                p => p.Unidade,
                p => p.PrecoVenda,
                p => p.PrecoCusto,
                p => p.Observacao,
                p => p.DataAtualizacao);
           
            var result = await _repositoryProduto.SaveChangeAsync(cancellationToken);
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateProdutoAsync));
            return result ? ResponseDto.Sucess("Atualizado com sucesso", HttpStatusCode.NoContent) : ResponseDto.Fail(Constants.DefaultFail);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(UpdateProdutoAsync));
        }
    }
}