using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;

namespace MicroErp.Application.OrdemServicoCases.FindOneOrdem;

public class FindOneOrdemRequest: FindOneOrdemRequestDto, IRequest<ResponseDto<FindOneOrdemResponseDto>>
{
    
}