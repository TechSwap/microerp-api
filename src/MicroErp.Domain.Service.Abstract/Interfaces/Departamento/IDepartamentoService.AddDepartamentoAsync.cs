using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Departamento;

public partial interface IDepartamentoService
{
    Task<ResponseDto<None>> AddDepartamentoAsync(AddDepartamentoRequestDto request, CancellationToken cancellationToken);
}