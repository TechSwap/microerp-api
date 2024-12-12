using MediatR;
using MicroErp.Application.DepartamentoCases.FindOneDepartamento;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.ActiveDepartamento;

public class ActiveDepartamentoHandler: IRequestHandler<ActiveDepartamentoRequest, ResponseDto<None>>
{
    private readonly IDepartamentoService _departamentoService;

    public ActiveDepartamentoHandler(IDepartamentoService departamentoService) => _departamentoService = departamentoService;
    public async Task<ResponseDto<None>> Handle(ActiveDepartamentoRequest request, CancellationToken cancellationToken)
    {
        return await _departamentoService.ActiveDepartamentoAsync(request, cancellationToken);
    }
}