using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.ActiveFuncionario;

public class ActiveFuncionarioRequest: FindOneFuncionarioRequestDto,  IRequest<ResponseDto<None>>
{
    
}