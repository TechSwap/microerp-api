using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Maquina;

public partial interface IMaquinaService
{
    Task<ResponseDto<IEnumerable<ListMaquinasResponseDto>>> ListMaquinasAsync(ListMaquinasRequestDto request, CancellationToken cancellationToken);
}