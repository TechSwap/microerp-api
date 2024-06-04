using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.ListDepartamentos;

namespace MicroErp.Application.DepartamentoCases.ListDepartamentos;

public class ListDepartamentosRequest: ListDepartamentosRequestDto, IRequest<ResponseDto<IEnumerable<ListDepartamentosResponseDto>>>
{
    
}