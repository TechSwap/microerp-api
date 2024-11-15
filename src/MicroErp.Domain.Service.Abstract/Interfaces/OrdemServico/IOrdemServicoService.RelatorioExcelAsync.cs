using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.Relatorio;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

public partial interface IOrdemServicoService
{
    Task<ResponseDto<RelatorioExcelResponseDto>> RelatorioExcelAsync(RelatorioExcelRequestDto request, CancellationToken cancellationToken);
}

