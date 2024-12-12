using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Departamento;

public partial interface IDepartamentoService
{
    Task<ResponseDto<None>> DeleteDepartamentoAsync(FindOneDepartamentoRequestDto request, CancellationToken cancellationToken);
}