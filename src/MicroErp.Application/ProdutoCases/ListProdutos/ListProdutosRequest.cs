using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;

namespace MicroErp.Application.ProdutoCases.AddProduto;

public class ListProdutosRequest: ListProdutosRequestDto, IRequest<ResponseDto<IEnumerable<ListProdutosResponseDto>>>
{
    
}