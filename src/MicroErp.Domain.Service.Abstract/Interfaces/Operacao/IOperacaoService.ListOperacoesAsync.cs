using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Operacao;

public partial interface IOperacaoService
{
    Task<ResponseDto<IEnumerable<ListOperacoesResponseDto>>> ListOperacoesAsync(ListOperacoesRequestDto request, CancellationToken cancellationToken);
}