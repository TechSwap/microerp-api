using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.UpdateDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Departamento;

public partial interface IDepartamentoService
{
    Task<ResponseDto<None>> UpdateDepartamentoAsync(UpdateDepartamentoRequestDto request, CancellationToken cancellationToken);
}