using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.DeleteFuncionario;

public class DeleteFuncionarioHandler: IRequestHandler<DeleteFuncionarioRequest, ResponseDto<None>>
{
    private readonly IFuncionarioService _funcionarioService;
    public DeleteFuncionarioHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<None>> Handle(DeleteFuncionarioRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.DeleteFuncionarioAsync(request, cancellationToken);
    }  
}