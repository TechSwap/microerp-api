using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

namespace MicroErp.Application.OrdemServicoCases.FindOneOrdem;

public class FindOneOrdemHandler: IRequestHandler<FindOneOrdemRequest, ResponseDto<FindOneOrdemResponseDto>>
{
    private readonly IOrdemServicoService _ordemServicoService;

    public FindOneOrdemHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
   
    public Task<ResponseDto<FindOneOrdemResponseDto>> Handle(FindOneOrdemRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.FindOneOrdemAsync(request, cancellationToken);
    }
}