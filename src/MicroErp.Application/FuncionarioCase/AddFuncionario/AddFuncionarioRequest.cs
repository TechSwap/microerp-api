using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.AddFuncionario;

public class AddFuncionarioRequest: AddFuncionarioRequestDto,  IRequest<ResponseDto<None>>
{
    
}