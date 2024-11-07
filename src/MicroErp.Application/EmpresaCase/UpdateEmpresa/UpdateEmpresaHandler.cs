using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Empresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.EmpresaCase.UpdateEmpresa;

public class UpdateEmpresaHandler: IRequestHandler<UpdateEmpresaRequest, ResponseDto<None>>
{
    private readonly IEmpresaService _empresaService;
    public UpdateEmpresaHandler(IEmpresaService empresaService) => _empresaService = empresaService;
    public async Task<ResponseDto<None>> Handle(UpdateEmpresaRequest request, CancellationToken cancellationToken)
    {
        return await _empresaService.UpdateEmpresaAsync(request, cancellationToken);
    }
}