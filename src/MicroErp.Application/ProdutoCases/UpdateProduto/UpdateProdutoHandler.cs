using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ProdutoCases.UpdateProduto;

public class UpdateProdutoHandler: IRequestHandler<UpdateProdutoRequest, ResponseDto<None>>
{
    private readonly IProdutoService _produtosService;
    public UpdateProdutoHandler(IProdutoService produtosService) => _produtosService = produtosService;
    
    public Task<ResponseDto<None>> Handle(UpdateProdutoRequest request, CancellationToken cancellationToken)
    {
        return _produtosService.UpdateProdutoAsync(request, cancellationToken);
    }
}