using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.UpdateMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.UpdateMaquina;

public class UpdateMaquinaRequest: UpdateMaquinaRequestDto,  IRequest<ResponseDto<None>>
{
    
}