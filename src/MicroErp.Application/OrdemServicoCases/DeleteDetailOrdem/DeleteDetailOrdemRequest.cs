using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemServicoCases.DeleteDetailOrdem;

public class DeleteDetailOrdemRequest: DetatlheOrdemServicoRequestDto,  IRequest<ResponseDto<None>>
{
    
}