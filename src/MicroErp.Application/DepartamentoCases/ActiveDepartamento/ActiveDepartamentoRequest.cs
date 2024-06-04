using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.ActiveDepartamento;

public class ActiveDepartamentoRequest: FindOneDepartamentoRequestDto, IRequest<ResponseDto<None>>
{
    
}