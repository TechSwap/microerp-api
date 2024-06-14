using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.GetCodigoFuncionario;

namespace MicroErp.Application.FuncionarioCase.GetCodigoFuncionario;

public class GetCodigoFuncionarioRequest: GetCodigoFuncionarioRequestDto,  IRequest<ResponseDto<GetCodigoFuncionarioResponseDto>>
{
    
}