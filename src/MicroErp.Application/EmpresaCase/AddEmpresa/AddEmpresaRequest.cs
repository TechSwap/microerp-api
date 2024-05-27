using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.EmpresaCase.AddEmpresa;

public class AddEmpresaRequest: AddEmpresaRequestDto, IRequest<ResponseDto<None>>
{
    
}