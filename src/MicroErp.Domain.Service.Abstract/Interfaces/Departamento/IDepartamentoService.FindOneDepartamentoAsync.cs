using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Departamento;

public partial interface IDepartamentoService
{
    Task<ResponseDto<FindOneDepartamentoResponseDto>> FindOneDepartamentoAsync(FindOneDepartamentoRequestDto request, CancellationToken cancellationToken);
}