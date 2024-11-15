using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.Relatorio;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

namespace MicroErp.Application.OrdemServicoCases.Relatorio;

public class RelatorioExcelHandler: IRequestHandler<RelatorioExcelRequest, ResponseDto<RelatorioExcelResponseDto>>
{
    private readonly IOrdemServicoService _ordemServicoService;

    public RelatorioExcelHandler(IOrdemServicoService ordemServicoService) => _ordemServicoService = ordemServicoService;
    public Task<ResponseDto<RelatorioExcelResponseDto>> Handle(RelatorioExcelRequest request, CancellationToken cancellationToken)
    {
        return _ordemServicoService.RelatorioExcelAsync(request, cancellationToken);
    }
}