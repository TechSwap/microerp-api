using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.UpdateEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.EmpresaCase.UpdateEmpresa;

public class UpdateEmpresaRequest: UpdateEmpresaRequestDto, IRequest<ResponseDto<None>>
{
    
}