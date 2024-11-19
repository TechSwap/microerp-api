using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;

namespace MicroErp.Application.MaquinaCases.ListMaquinas;

public class ListMaquinasRequest: ListMaquinasRequestDto, IRequest<ResponseDto<IEnumerable<ListMaquinasResponseDto>>>
{
    
}