using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.UpdateDepartamento;

public class UpdateDepartamentoHandler: IRequestHandler<UpdateDepartamentoRequest, ResponseDto<None>>
{
    private readonly IDepartamentoService _departamentoService;
    public UpdateDepartamentoHandler(IDepartamentoService departamentoService) => _departamentoService = departamentoService;
    public async Task<ResponseDto<None>> Handle(UpdateDepartamentoRequest request, CancellationToken cancellationToken)
    {
        return await _departamentoService.UpdateDepartamentoAsync(request, cancellationToken);
    }
}