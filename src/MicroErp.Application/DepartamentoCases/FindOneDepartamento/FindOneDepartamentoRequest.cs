using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;

namespace MicroErp.Application.DepartamentoCases.FindOneDepartamento;

public class FindOneDepartamentoRequest: FindOneDepartamentoRequestDto, IRequest<ResponseDto<FindOneDepartamentoResponseDto>>
{
    
}