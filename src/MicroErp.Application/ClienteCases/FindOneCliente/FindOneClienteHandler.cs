using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;

namespace MicroErp.Application.ClienteCases.FindOneCliente;

public class FindOneClienteHandler: IRequestHandler<FindOneClienteRequest, ResponseDto<FindOneResponseDto>>
{
    private readonly IClienteService _clienteService;
    public FindOneClienteHandler(IClienteService clienteService) => _clienteService = clienteService;
    
    public async Task<ResponseDto<FindOneResponseDto>> Handle(FindOneClienteRequest request, CancellationToken cancellationToken)
    {
        return await _clienteService.FindOneClienteAsync(request, cancellationToken);
    }
}