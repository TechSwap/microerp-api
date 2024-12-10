using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;

namespace MicroErp.Application.OrdemProducaoCases.FindOneOrdem;

public class FindOneOrdemProducaoRequest: FindOneOrdemProducaoRequestDto,  IRequest<ResponseDto<FindOneOdermProducaoResponseDto>>
{
    
}