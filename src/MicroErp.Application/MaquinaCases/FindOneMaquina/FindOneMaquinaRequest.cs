using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;

namespace MicroErp.Application.MaquinaCases.FindOneMaquina;

public class FindOneMaquinaRequest: FindOneMaquinaRequestDto,  IRequest<ResponseDto<FindOneMaquinaResponseDto>>
{
    
}