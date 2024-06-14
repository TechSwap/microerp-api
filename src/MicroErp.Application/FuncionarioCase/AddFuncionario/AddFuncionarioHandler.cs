using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.AddFuncionario;

public class AddFuncionarioHandler: IRequestHandler<AddFuncionarioRequest, ResponseDto<None>>
{
    private readonly IFuncionarioService _funcionarioService;
    public AddFuncionarioHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<None>> Handle(AddFuncionarioRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.AddFuncionarioAsync(request, cancellationToken);
    }
}