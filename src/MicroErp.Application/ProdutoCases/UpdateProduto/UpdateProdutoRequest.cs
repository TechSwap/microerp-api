using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.UpdateProduto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ProdutoCases.UpdateProduto;

public class UpdateProdutoRequest: UpdateProdutoRequestDto, IRequest<ResponseDto<None>>
{
    
}