using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.PrintOrdem;

namespace MicroErp.Application.OrdemProducaoCases.PrintOrdem;

public class PrintOrdemProducaoRequest: PrintOrdemProducaoRequestDto,  IRequest<ResponseDto<PrintOrdemProducaoResponseDto>>
{
    
}