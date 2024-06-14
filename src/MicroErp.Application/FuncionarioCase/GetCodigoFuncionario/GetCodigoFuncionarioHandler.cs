using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.GetCodigoFuncionario;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

namespace MicroErp.Application.FuncionarioCase.GetCodigoFuncionario;

public class GetCodigoFuncionarioHandler: IRequestHandler<GetCodigoFuncionarioRequest, ResponseDto<GetCodigoFuncionarioResponseDto>>
{
    private readonly IFuncionarioService _funcionarioService;
    public GetCodigoFuncionarioHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<GetCodigoFuncionarioResponseDto>> Handle(GetCodigoFuncionarioRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.GetCodigoFuncionarioAsync(request, cancellationToken);
    }
}