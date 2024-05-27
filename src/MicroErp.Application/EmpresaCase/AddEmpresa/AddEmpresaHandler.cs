using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Empresas;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.EmpresaCase.AddEmpresa;

public class AddEmpresaHandler: IRequestHandler<AddEmpresaRequest, ResponseDto<None>>
{
    private readonly IEmpresaService _empresaService;

    public AddEmpresaHandler(IEmpresaService empresaService) => _empresaService = empresaService;
    
    public async Task<ResponseDto<None>> Handle(AddEmpresaRequest request, CancellationToken cancellationToken)
    {
        return await _empresaService.AddEmpresaAsync(request, cancellationToken);
    }
}