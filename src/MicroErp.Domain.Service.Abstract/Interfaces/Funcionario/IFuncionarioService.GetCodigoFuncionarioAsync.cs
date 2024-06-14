using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.GetCodigoFuncionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

public partial interface IFuncionarioService
{
    Task<ResponseDto<GetCodigoFuncionarioResponseDto>> GetCodigoFuncionarioAsync(GetCodigoFuncionarioRequestDto request, CancellationToken cancellationToken);
}