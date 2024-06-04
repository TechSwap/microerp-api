using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.AddDepartamento;

public class AddDepartamentoRequest: AddDepartamentoRequestDto, IRequest<ResponseDto<None>>
{
    
}