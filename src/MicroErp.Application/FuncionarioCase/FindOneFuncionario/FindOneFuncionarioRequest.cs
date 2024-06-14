using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;

namespace MicroErp.Application.FuncionarioCase.FindOneFuncionario;

public class FindOneFuncionarioRequest: FindOneFuncionarioRequestDto,  IRequest<ResponseDto<FindOneFuncionarioResponseDto>>
{
    
}