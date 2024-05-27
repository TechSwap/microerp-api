using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

public interface IFuncionarioService
{
    Task<ResponseDto<None>> AddFuncionarioAsync(AddFuncionarioRequestDto request, CancellationToken cancellationToken);
}