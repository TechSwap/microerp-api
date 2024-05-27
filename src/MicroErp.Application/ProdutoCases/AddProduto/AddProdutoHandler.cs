using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ProdutoCases.AddProduto;

public class AddProdutoHandler : IRequestHandler<AddProdutoRequest, ResponseDto<None>>
{
    private readonly IProdutoService _produtosService;

    public AddProdutoHandler(IProdutoService produtosService) => _produtosService = produtosService;
    
    public Task<ResponseDto<None>> Handle(AddProdutoRequest request, CancellationToken cancellationToken)
    {
        return _produtosService.AddProdutoAsync(request, cancellationToken);
    }
}