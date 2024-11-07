using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.UpdateEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Empresa;

public partial interface IEmpresaService
{
    Task<ResponseDto<None>> UpdateEmpresaAsync(UpdateEmpresaRequestDto request, CancellationToken cancellationToken);
}