using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemServicoCases.AddOrdem;

public class AddOrdemRequest: AddOrdemRequestDto,  IRequest<ResponseDto<None>>
{
    
}