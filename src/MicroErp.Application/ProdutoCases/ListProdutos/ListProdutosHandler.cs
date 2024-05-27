using MediatR;
using MicroErp.Application.ProdutoCases.AddProduto;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;

namespace MicroErp.Application.ProdutoCases.ListProdutos;

public class ListProdutosHandler: IRequestHandler<ListProdutosRequest, ResponseDto<IEnumerable<ListProdutosResponseDto>>>
{
    private readonly IProdutoService _produtosService;

    public ListProdutosHandler(IProdutoService produtosService) => _produtosService = produtosService;
   
    public Task<ResponseDto<IEnumerable<ListProdutosResponseDto>>> Handle(ListProdutosRequest request, CancellationToken cancellationToken)
    {
        return _produtosService.ListProdutosAsync(request, cancellationToken);
    }
}