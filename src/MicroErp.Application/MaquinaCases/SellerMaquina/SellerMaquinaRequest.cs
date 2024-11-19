using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.SellerMaquina;

public class SellerMaquinaRequest: FindOneMaquinaRequestDto,  IRequest<ResponseDto<None>>
{
    
}