using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.AddProduto;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Produto;

public partial interface IProdutoService
{
    Task<ResponseDto<IEnumerable<ListProdutosResponseDto>>> ListProdutosAsync(ListProdutosRequestDto request, CancellationToken cancellationToken);
}