using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.DeleteDepartamento;

public class DeleteDepartamentoRequest: FindOneDepartamentoRequestDto, IRequest<ResponseDto<None>>
{
    
}