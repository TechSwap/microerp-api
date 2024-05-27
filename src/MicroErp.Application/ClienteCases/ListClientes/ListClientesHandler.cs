using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;

namespace MicroErp.Application.ClienteCases.ListClientes;

public class ListClientesHandler: IRequestHandler<ListClientesRequest, ResponseDto<IEnumerable<ListClientesResponseDto>>>
{
    private readonly IClienteService _clienteService;

    public ListClientesHandler(IClienteService clienteService) => _clienteService = clienteService;
    
    public async Task<ResponseDto<IEnumerable<ListClientesResponseDto>>> Handle(ListClientesRequest request, CancellationToken cancellationToken)
    {
        return await _clienteService.ListClientesAsync(request, cancellationToken);
    }

}