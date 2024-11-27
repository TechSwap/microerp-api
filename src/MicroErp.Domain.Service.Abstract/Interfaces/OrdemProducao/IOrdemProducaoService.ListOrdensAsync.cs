using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;

public partial interface IOrdemProducaoService
{
    Task<ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>> ListOrdensAsync(ListOrdensProducaoRequestDto request, CancellationToken cancellationToken);
}