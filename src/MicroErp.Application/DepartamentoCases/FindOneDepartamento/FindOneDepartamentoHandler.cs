using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;

namespace MicroErp.Application.DepartamentoCases.FindOneDepartamento;

public class FindOneDepartamentoHandler: IRequestHandler<FindOneDepartamentoRequest, ResponseDto<FindOneDepartamentoResponseDto>>
{
    private readonly IDepartamentoService _departamentoService;
    public FindOneDepartamentoHandler(IDepartamentoService departamentoService) => _departamentoService = departamentoService;
    public async Task<ResponseDto<FindOneDepartamentoResponseDto>> Handle(FindOneDepartamentoRequest request, CancellationToken cancellationToken)
    {
        return await _departamentoService.FindOneDepartamentoAsync(request, cancellationToken);
    }
}