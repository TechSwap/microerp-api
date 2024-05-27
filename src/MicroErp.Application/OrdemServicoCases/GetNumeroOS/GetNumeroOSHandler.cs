using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.GetNumeroOS;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

namespace MicroErp.Application.OrdemServicoCases.GetNumeroOS;

public class GetNumeroOSHandler: IRequestHandler<GetNumeroOSRequest, ResponseDto<GetNumeroOSResponseDto>>
{
    private readonly IOrdemServicoService _ordemServicoService;
    public GetNumeroOSHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
    
    public Task<ResponseDto<GetNumeroOSResponseDto>> Handle(GetNumeroOSRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.GetNumeroOSAsync(request, cancellationToken);
    }
}