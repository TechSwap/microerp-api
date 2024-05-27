using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;

namespace MicroErp.Application.ProdutoCases.FindOneProduto;

public class FindOneProdutoHandler: IRequestHandler<FindOneProdutoRequest, ResponseDto<FindOneProdutoResponseDto>>
{
    private readonly IProdutoService _produtosService;

    public FindOneProdutoHandler(IProdutoService produtosService) => _produtosService = produtosService;
   
    public Task<ResponseDto<FindOneProdutoResponseDto>> Handle(FindOneProdutoRequest request, CancellationToken cancellationToken)
    {
        return _produtosService.FindOneProdutoAsync(request, cancellationToken);
    }
}