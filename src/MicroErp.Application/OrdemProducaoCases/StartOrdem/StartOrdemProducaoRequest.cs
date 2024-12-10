using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemProducaoCases.StartOrdem;

public class StartOrdemProducaoRequest: FindOneOrdemProducaoRequestDto,  IRequest<ResponseDto<None>>
{
    
}