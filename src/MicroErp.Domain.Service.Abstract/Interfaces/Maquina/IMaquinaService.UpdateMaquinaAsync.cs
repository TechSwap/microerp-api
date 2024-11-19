using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.UpdateMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Maquina;

public partial interface IMaquinaService
{
    Task<ResponseDto<None>> UpdateMaquinaAsync(UpdateMaquinaRequestDto request, CancellationToken cancellationToken);
}