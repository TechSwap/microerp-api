using System.Net;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.AddProduto;
using MicroErp.Domain.Utils;
using MicroErp.Infra.CrossCuting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Produtos;

public partial class ProdutoService
{
    public async Task<ResponseDto<None>> AddProdutoAsync(AddProdutoRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(AddProdutoAsync));
        try
        {
            var existProduto = await _repositoryProduto.Query.Where(p => p.Descricao.Contains(request.Descricao)).FirstOrDefaultAsync();
            
            var codigoProduto = await _repositoryProduto.Query.OrderBy(p => p.Codigo).Select(p => p.Codigo).LastOrDefaultAsync();

            if (existProduto == null)
            {
                var codigo = codigoProduto != null ? codigoProduto + 1 : 1;
                var produto = new Produto
                {
                    Id = Guid.NewGuid().ToString().ToLower(),
                    Codigo = codigo,
                    Descricao = request.Descricao,
                    Unidade = request.Unidade,
                    PrecoCusto = request.PrecoCusto != 0 ? request.PrecoCusto : 0,
                    PrecoVenda = request.PrecoVenda != 0 ? request.PrecoVenda : 0,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    FornecedorId = request.IsFornecedor.Equals(true) ? request.FornecedorId : null,
                    ClienteId = request.IsCliente.Equals(true) ? request.ClienteId : null,
                    Observacao = string.IsNullOrEmpty(request.Observacao) ? null : request.Observacao
                };

                await _repositoryProduto.InsertAsync(produto, cancellationToken);
                await _repositoryProduto.SaveChangeAsync(cancellationToken);
            }
            else
            {
                return ResponseDto.Sucess("Produto já cadastrado", HttpStatusCode.BadRequest);
            }

            return ResponseDto.Sucess("Produto cadastrado com sucesso", HttpStatusCode.NoContent);
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
            logger.LogInformation("Metodo finalizado:{0}", nameof(AddProdutoAsync));
        }
    }
}