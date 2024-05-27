using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ClienteCases.DeleteCliente;

public class DeleteClienteHandler: IRequestHandler<DeleteClienteRequest, ResponseDto<None>>
{
    private readonly IClienteService _clienteService;
    public DeleteClienteHandler(IClienteService clienteService) => _clienteService = clienteService;
    
    public async Task<ResponseDto<None>> Handle(DeleteClienteRequest request, CancellationToken cancellationToken)
    {
        return await _clienteService.DeleteClienteAsync(request, cancellationToken);
    }
}