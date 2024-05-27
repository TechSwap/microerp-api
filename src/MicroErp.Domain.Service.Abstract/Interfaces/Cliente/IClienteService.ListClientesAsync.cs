using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Cliente;

public partial interface IClienteService
{
    Task<ResponseDto<IEnumerable<ListClientesResponseDto>>> ListClientesAsync(ListClientesRequestDto request, CancellationToken cancellationToken);
}