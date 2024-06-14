using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

namespace MicroErp.Application.FuncionarioCase.FindOneFuncionario;

public class FindOneFuncionarioHandler: IRequestHandler<FindOneFuncionarioRequest, ResponseDto<FindOneFuncionarioResponseDto>>
{
    private readonly IFuncionarioService _funcionarioService;
    public FindOneFuncionarioHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<FindOneFuncionarioResponseDto>> Handle(FindOneFuncionarioRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.FindOneFuncionarioAsync(request, cancellationToken);
    }
}