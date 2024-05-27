using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemServicoCases.UpdateOrdem;

public class UpdateOrdemHandler: IRequestHandler<UpdateOrdemRequest, ResponseDto<None>>
{
    private readonly IOrdemServicoService _ordemServicoService;

    public UpdateOrdemHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
    
    public Task<ResponseDto<None>> Handle(UpdateOrdemRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.UpdateOrdemAsync(request, cancellationToken);
    }
}