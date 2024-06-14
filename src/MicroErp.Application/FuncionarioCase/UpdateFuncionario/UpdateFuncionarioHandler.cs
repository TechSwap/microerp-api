using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FuncionarioCase.UpdateFuncionario;

public class UpdateFuncionarioHandler: IRequestHandler<UpdateFuncionarioRequest, ResponseDto<None>>
{
    private readonly IFuncionarioService _funcionarioService;
    public UpdateFuncionarioHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<None>> Handle(UpdateFuncionarioRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.UpdateFuncionarioAsync(request, cancellationToken);
    }
}