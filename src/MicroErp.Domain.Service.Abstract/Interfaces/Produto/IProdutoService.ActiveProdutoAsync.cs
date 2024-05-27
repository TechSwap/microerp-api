using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Produto;

public partial interface IProdutoService
{
    Task<ResponseDto<None>> ActiveProdutoAsync(FindOneProdutoRequestDto request, CancellationToken cancellationToken);
}