using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.DepartamentoCases.AddDepartamento;

public class AddDepartamentoHandler: IRequestHandler<AddDepartamentoRequest, ResponseDto<None>>
{
    private readonly IDepartamentoService _departamentoService;
    public AddDepartamentoHandler(IDepartamentoService departamentoService) => _departamentoService = departamentoService;
   
    public async Task<ResponseDto<None>> Handle(AddDepartamentoRequest request, CancellationToken cancellationToken)
    {
        return await _departamentoService.AddDepartamentoAsync(request, cancellationToken);
    }
}