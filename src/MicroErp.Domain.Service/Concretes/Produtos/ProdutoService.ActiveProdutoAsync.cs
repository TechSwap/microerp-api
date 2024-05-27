using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.AddProduto;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Produtos;

public partial class ProdutoService
{
    public async  Task<ResponseDto<None>> ActiveProdutoAsync(FindOneProdutoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ActiveProdutoAsync));
        try
        {
            var produto = await _repositoryProduto.GetByOneAsync(p => p.Id == request.IdProduto, cancellationToken);

            if (produto == null)
            {
                return ResponseDto.Fail(HttpStatusCode.NotFound);
            }

            produto.Ativo = !produto.Ativo;
            produto.DataAtualizacao = DateTime.Now;
            
            await _repositoryProduto.UpdateAsync(produto, cancellationToken,
                p => p.Ativo,
                p => p.DataAtualizacao);
           
            var result = await _repositoryProduto.SaveChangeAsync(cancellationToken);
            logger.LogInformation("Metodo finalizado:{0}", nameof(ActiveProdutoAsync));
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneProdutoAsync));
        }
    }
}