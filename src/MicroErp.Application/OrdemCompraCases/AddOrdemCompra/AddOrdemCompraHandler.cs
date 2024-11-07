using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemCompra;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemCompraCases.AddOrdemCompra;

public class AddOrdemCompraHandler: IRequestHandler<AddOrdemCompraRequest, ResponseDto<None>>
{
    private readonly IOrdemCompraService _ordemCompraService;
    public AddOrdemCompraHandler(IOrdemCompraService ordemCompraService) => _ordemCompraService = ordemCompraService;
    public Task<ResponseDto<None>> Handle(AddOrdemCompraRequest request, CancellationToken cancellationToken)
    {
        return _ordemCompraService.AddOrdemCompraAsync(request, cancellationToken);
    }
}