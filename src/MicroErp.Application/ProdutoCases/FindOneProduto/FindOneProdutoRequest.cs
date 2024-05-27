using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;

namespace MicroErp.Application.ProdutoCases.FindOneProduto;

public class FindOneProdutoRequest: FindOneProdutoRequestDto, IRequest<ResponseDto<FindOneProdutoResponseDto>>
{
    
}