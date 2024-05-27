using System.Net;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Produtos;

public partial class ProdutoService
{
    public async Task<ResponseDto<IEnumerable<ListProdutosResponseDto>>> ListProdutosAsync(ListProdutosRequestDto request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Metodo iniciado:{0}", nameof(ListProdutosAsync));
        try
        {
            var entity = _mapper.Map<PaginatedMetaDataEntity>(request);
            var result = await _repositoryProduto.GetPaginatedAsync(
                request.ColunmSort,
                entity,
                cancellationToken);
            var metaData = new MetaDataResponse
            {
                PageNumber = request.MetaData.PageNumber,
                PageSize = request.MetaData.PageSize,
            };
            
            List<ListProdutosResponseDto> itens = new List<ListProdutosResponseDto>();

            foreach (var itm in result.Items)
            {
                 var prod = new ListProdutosResponseDto
                {
                    IdProduto = itm.Id,
                    Codigo = (long)itm.Codigo,
                    Descricao = itm.Descricao,
                    Unidade = itm.Unidade,
                    Ativo = itm.Ativo,
                    PrecoVenda = (decimal)itm.PrecoVenda,
                    PrecoCusto = (decimal)itm.PrecoCusto,
                    FornecedorId = itm.FornecedorId,
                    ClienteId = itm.ClienteId
                };

                itens.Add(prod);
            }

            metaData.TotalPages = (itens.Count / request.MetaData.PageSize);
            metaData.TotalRecords = itens.Count;

            if (itens.Count != 0)
            {
                return ResponseDto<IEnumerable<ListProdutosResponseDto>>.Sucess(itens, metaData);
            }
            else
            {
                return ResponseDto<IEnumerable<ListProdutosResponseDto>>.Sucess(itens, metaData, HttpStatusCode.NoContent);
            }
        }
        catch (Exception e)
        {
            var fail = ErrorResponse.CreateError(Constants.DefaultFail)
                .WithDeveloperMessage(e.Message)
                .WithStackTrace(e.StackTrace)
                .WithException(e.ToString());
            return ResponseDto<IEnumerable<ListProdutosResponseDto>>.Fail(fail);
        }
        finally
        {
            logger.LogInformation("Metodo finalizado:{0}", nameof(ListProdutosAsync));
        }
    }
}