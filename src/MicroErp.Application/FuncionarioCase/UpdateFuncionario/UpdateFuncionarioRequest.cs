using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.UpdateFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.UpdateFuncionario;

public class UpdateFuncionarioRequest: UpdateFuncionarioRequestDto,  IRequest<ResponseDto<None>>
{
    
}