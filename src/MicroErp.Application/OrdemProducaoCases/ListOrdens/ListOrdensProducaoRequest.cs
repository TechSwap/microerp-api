using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;

namespace MicroErp.Application.OrdemProducaoCases.ListOrdens;

public class ListOrdensProducaoRequest: ListOrdensProducaoRequestDto,  IRequest<ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>>
{
    
}