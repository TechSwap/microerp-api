using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Empresa;

public partial interface IEmpresaService
{
    Task<ResponseDto<GetEmpresaResponseDto>> GetEmpresaAsync(GetEmpresaRequestDto request, CancellationToken cancellationToken);
}