using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Cliente;

public partial interface IClienteService
{
    Task<ResponseDto<FindOneResponseDto>> FindOneClienteAsync(FindOneRequestDto request, CancellationToken cancellationToken);
}