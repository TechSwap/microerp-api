using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

public partial interface IFuncionarioService
{
    Task<ResponseDto<FindOneFuncionarioResponseDto>> FindOneFuncionarioAsync(FindOneFuncionarioRequestDto request, CancellationToken cancellationToken);
}