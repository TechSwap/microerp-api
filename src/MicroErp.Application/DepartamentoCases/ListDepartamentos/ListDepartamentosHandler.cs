using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.ListDepartamentos;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;

namespace MicroErp.Application.DepartamentoCases.ListDepartamentos;

public class ListDepartamentosHandler: IRequestHandler<ListDepartamentosRequest, ResponseDto<IEnumerable<ListDepartamentosResponseDto>>>
{
    private readonly IDepartamentoService _departamentoService;
    public ListDepartamentosHandler(IDepartamentoService departamentoService) => _departamentoService = departamentoService;
    public async Task<ResponseDto<IEnumerable<ListDepartamentosResponseDto>>> Handle(ListDepartamentosRequest request, CancellationToken cancellationToken)
    {
        return await _departamentoService.ListDepartamentosAsync(request, cancellationToken);
    }
}