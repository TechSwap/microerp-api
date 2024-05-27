using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.GetNumeroOS;

namespace MicroErp.Application.OrdemServicoCases.GetNumeroOS;

public class GetNumeroOSRequest: GetNumeroOSRequestDto,  IRequest<ResponseDto<GetNumeroOSResponseDto>>
{
    
}