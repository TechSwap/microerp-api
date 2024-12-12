using MediatR;
using MicroErp.Application.DepartamentoCases.ActiveDepartamento;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.DeleteDepartamento;

public  class DeleteDepartamentoHandler: IRequestHandler<DeleteDepartamentoRequest, ResponseDto<None>>
{
    private readonly IDepartamentoService _departamentoService;

    public DeleteDepartamentoHandler(IDepartamentoService departamentoService) => _departamentoService = departamentoService;

    public async Task<ResponseDto<None>> Handle(DeleteDepartamentoRequest request, CancellationToken cancellationToken)
    {
        return await _departamentoService.DeleteDepartamentoAsync(request, cancellationToken);
    }
}