using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.AddProduto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ProdutoCases.AddProduto;

public class AddProdutoRequest: AddProdutoRequestDto, IRequest<ResponseDto<None>>
{
    
}