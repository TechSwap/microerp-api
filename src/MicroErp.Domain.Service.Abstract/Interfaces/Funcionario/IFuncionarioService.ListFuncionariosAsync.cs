using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

public partial interface IFuncionarioService
{
    Task<ResponseDto<IEnumerable<ListFuncionariosResponseDto>>> ListFuncionariosAsync(ListFuncionariosRequestDto request, CancellationToken cancellationToken);
}