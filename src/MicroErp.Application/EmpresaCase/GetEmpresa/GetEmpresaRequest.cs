using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;

namespace MicroErp.Application.EmpresaCase.GetEmpresa;

public class GetEmpresaRequest: GetEmpresaRequestDto, IRequest<ResponseDto<GetEmpresaResponseDto>>
{
    
}