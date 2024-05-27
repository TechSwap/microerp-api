using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ClienteCases.ActiveCliente;

public class ActiveClienteHandler: IRequestHandler<ActiveClienteRequest, ResponseDto<None>>
{
    private readonly IClienteService _clienteService;
    public ActiveClienteHandler(IClienteService clienteService) => _clienteService = clienteService;
    
    public async Task<ResponseDto<None>> Handle(ActiveClienteRequest request, CancellationToken cancellationToken)
    {
        return await _clienteService.ActiveClienteAsync(request, cancellationToken);
    }
}