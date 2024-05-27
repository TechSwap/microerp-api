using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

namespace MicroErp.Application.OrdemServicoCases.ListOrdens;

public class ListOrdensHandler: IRequestHandler<ListOrdensRequest, ResponseDto<IEnumerable<ListOrdensResponseDto>>>
{
    private readonly IOrdemServicoService _ordemServicoService;
    public ListOrdensHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
   
    public Task<ResponseDto<IEnumerable<ListOrdensResponseDto>>> Handle(ListOrdensRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.ListOrdensAsync(request, cancellationToken);
    }
}