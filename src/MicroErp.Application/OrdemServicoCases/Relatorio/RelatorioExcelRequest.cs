using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.Relatorio;

namespace MicroErp.Application.OrdemServicoCases.Relatorio;

public class RelatorioExcelRequest: RelatorioExcelRequestDto,  IRequest<ResponseDto<RelatorioExcelResponseDto>>
{
    
}