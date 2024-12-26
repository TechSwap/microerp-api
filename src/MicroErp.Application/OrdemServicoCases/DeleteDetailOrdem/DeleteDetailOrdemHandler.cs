using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemServicoCases.DeleteDetailOrdem;

public class DeleteDetailOrdemHandler: IRequestHandler<DeleteDetailOrdemRequest, ResponseDto<None>>
{
    private readonly IOrdemServicoService _ordemServicoService;

    public DeleteDetailOrdemHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
    public Task<ResponseDto<None>> Handle(DeleteDetailOrdemRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.DeleteDetailOrdemAsync(request, cancellationToken);
    }
}