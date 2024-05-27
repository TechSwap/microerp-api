using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.UpdateOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemServicoCases.UpdateOrdem;

public class UpdateOrdemRequest: UpdateOrdemRequestDto,  IRequest<ResponseDto<None>>
{
    
}