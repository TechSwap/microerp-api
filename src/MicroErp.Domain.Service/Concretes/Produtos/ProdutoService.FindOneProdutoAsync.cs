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
    public async Task<ResponseDto<FindOneProdutoResponseDto>> FindOneProdutoAsync(FindOneProdutoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(FindOneProdutoAsync));
        try
        {
            var result = await _repositoryProduto.GetByOneAsync(p => p.Id == request.IdProduto, cancellationToken);

            if (result == null)
            {
                return ResponseDto<FindOneProdutoResponseDto>.Fail(HttpStatusCode.NotFound);
            }

            var produto = new FindOneProdutoResponseDto
            {
                IdProduto = result.Id,
                Codigo = result.Codigo,
                Descricao = result.Descricao,
                Unidade = result.Unidade,
                Ativo = result.Ativo,
                PrecoVenda = result.PrecoVenda,
                PrecoCusto = result.PrecoCusto,
                FornecedorId = result.FornecedorId,
                ClienteId = result.ClienteId,
                Observacao = result.Observacao,
            };
            
            return ResponseDto<FindOneProdutoResponseDto>.Sucess(produto);
           
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<FindOneProdutoResponseDto>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(FindOneProdutoAsync));
        }
    }
}