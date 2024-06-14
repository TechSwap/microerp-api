using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.UpdateFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

public partial interface IFuncionarioService
{
    Task<ResponseDto<None>> UpdateFuncionarioAsync(UpdateFuncionarioRequestDto request, CancellationToken cancellationToken);
}