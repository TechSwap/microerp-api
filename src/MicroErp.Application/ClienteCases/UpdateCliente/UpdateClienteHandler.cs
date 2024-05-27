using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ClienteCases.UpdateCliente;

public class UpdateClienteHandler: IRequestHandler<UpdateClienteRequest, ResponseDto<None>>
{
    private readonly IClienteService _clienteService;

    public UpdateClienteHandler(IClienteService clienteService) => _clienteService = clienteService;
    
    public async Task<ResponseDto<None>> Handle(UpdateClienteRequest request, CancellationToken cancellationToken)
    {
        return await _clienteService.UpdateClienteAsync(request, cancellationToken);
    }
}