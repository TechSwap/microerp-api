using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Maquina;

public partial interface IMaquinaService
{
    Task<ResponseDto<None>> ActiveMaquinaAsync(FindOneMaquinaRequestDto request, CancellationToken cancellationToken);
}