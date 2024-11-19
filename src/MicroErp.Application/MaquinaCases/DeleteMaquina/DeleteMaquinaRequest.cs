using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.DeleteMaquina;

public class DeleteMaquinaRequest: FindOneMaquinaRequestDto,  IRequest<ResponseDto<None>>
{
    
}