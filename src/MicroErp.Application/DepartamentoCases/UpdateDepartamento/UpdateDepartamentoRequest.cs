using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.UpdateDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.UpdateDepartamento;

public class UpdateDepartamentoRequest: UpdateDepartamentoRequestDto, IRequest<ResponseDto<None>>
{
    
}