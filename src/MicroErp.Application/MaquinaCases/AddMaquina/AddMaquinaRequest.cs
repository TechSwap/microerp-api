using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.AddMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.AddMaquina;

public class AddMaquinaRequest: AddMaquinaRequestDto,  IRequest<ResponseDto<None>>
{
    
}