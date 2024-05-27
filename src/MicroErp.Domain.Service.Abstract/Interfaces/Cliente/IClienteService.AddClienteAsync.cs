using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Cliente;

public partial interface IClienteService
{
    Task<ResponseDto<None>> AddClienteAsync(AddEmpresaRequestDto request, CancellationToken cancellationToken);
}