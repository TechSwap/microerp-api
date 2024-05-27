using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;

namespace MicroErp.Application.ClienteCases.ListClientes;

public class ListClientesRequest : ListClientesRequestDto, IRequest<ResponseDto<IEnumerable<ListClientesResponseDto>>>
{
    
}