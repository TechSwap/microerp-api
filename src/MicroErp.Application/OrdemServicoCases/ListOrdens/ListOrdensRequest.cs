using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;

namespace MicroErp.Application.OrdemServicoCases.ListOrdens;

public class ListOrdensRequest: ListOrdensRequestDto, IRequest<ResponseDto<IEnumerable<ListOrdensResponseDto>>>
{
    
}