using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;

namespace MicroErp.Application.FuncionarioCase.ListFuncionarios;

public class ListFuncionariosHandler: IRequestHandler<ListFuncionariosRequest, ResponseDto<IEnumerable<ListFuncionariosResponseDto>>>
{
    private readonly IFuncionarioService _funcionarioService;
    public ListFuncionariosHandler(IFuncionarioService funcionarioService) => _funcionarioService = funcionarioService;
    public Task<ResponseDto<IEnumerable<ListFuncionariosResponseDto>>> Handle(ListFuncionariosRequest request, CancellationToken cancellationToken)
    {
        return _funcionarioService.ListFuncionariosAsync(request, cancellationToken);
    }
}