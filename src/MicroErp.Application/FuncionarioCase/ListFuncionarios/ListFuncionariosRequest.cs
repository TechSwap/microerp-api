using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;

namespace MicroErp.Application.FuncionarioCase.ListFuncionarios;

public class ListFuncionariosRequest: ListFuncionariosRequestDto, IRequest<ResponseDto<IEnumerable<ListFuncionariosResponseDto>>>
{
    
}