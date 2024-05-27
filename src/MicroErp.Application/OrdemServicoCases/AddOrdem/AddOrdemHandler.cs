using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemServicoCases.AddOrdem;

public class AddOrdemHandler: IRequestHandler<AddOrdemRequest, ResponseDto<None>>
{
    private readonly IOrdemServicoService _ordemServicoService;

    public AddOrdemHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
   
    public Task<ResponseDto<None>> Handle(AddOrdemRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.AddOrdemAsync(request, cancellationToken);
    }
}