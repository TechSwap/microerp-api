using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ProdutoCases.ActiveProduto;

public class ActiveProdutoHandler: IRequestHandler<ActiveProdutoRequest, ResponseDto<None>>
{
    private readonly IProdutoService _produtosService;
    public ActiveProdutoHandler(IProdutoService produtosService) => _produtosService = produtosService;
   
    public Task<ResponseDto<None>> Handle(ActiveProdutoRequest request, CancellationToken cancellationToken)
    {
        return _produtosService.ActiveProdutoAsync(request, cancellationToken);
    }
}