using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ProdutoCases.ActiveProduto;

public class ActiveProdutoRequest: FindOneProdutoRequestDto,  IRequest<ResponseDto<None>>
{
    
}