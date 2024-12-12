using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.CancellyOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemProducaoCases.CancellyOrdem;

public class CancellyOrdemProducaoRequest: CancellyOrdemRequestDto,  IRequest<ResponseDto<None>>
{
    
}