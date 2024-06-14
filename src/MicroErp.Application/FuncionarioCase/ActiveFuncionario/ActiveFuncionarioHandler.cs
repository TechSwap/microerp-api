using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.ActiveFuncionario;

public class ActiveFuncionarioHandler: IRequestHandler<ActiveFuncionarioRequest, ResponseDto<None>>
{
    private readonly IFuncionarioService _funcionarioService;
    public ActiveFuncionarioHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<None>> Handle(ActiveFuncionarioRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.ActiveFuncionarioAsync(request, cancellationToken);
    }   
}