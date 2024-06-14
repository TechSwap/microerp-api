using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.DeleteFuncionario;

public class DeleteFuncionarioRequest: FindOneFuncionarioRequestDto,  IRequest<ResponseDto<None>>
{
    
}