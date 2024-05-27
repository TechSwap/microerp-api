using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Produto;

public partial interface IProdutoService
{
    Task<ResponseDto<FindOneProdutoResponseDto>> FindOneProdutoAsync(FindOneProdutoRequestDto request, CancellationToken cancellationToken);
}