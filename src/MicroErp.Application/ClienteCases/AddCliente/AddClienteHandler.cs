using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ClienteCases.AddCliente;

public class AddClienteHandler: IRequestHandler<AddClienteRequest, ResponseDto<None>>
{
    private readonly IClienteService _clienteService;

    public AddClienteHandler(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }
    
    public async Task<ResponseDto<None>> Handle(AddClienteRequest request, CancellationToken cancellationToken)
    {
        return await _clienteService.AddClienteAsync(request, cancellationToken);
    }
}