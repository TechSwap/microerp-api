using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Domain.Service.Abstract.Interfaces.Empresa;

namespace MicroErp.Application.EmpresaCase.GetEmpresa;

public class GetEmpresaHandler: IRequestHandler<GetEmpresaRequest, ResponseDto<GetEmpresaResponseDto>>
{
    private readonly IEmpresaService _empresaService;
    public GetEmpresaHandler(IEmpresaService empresaService) => _empresaService = empresaService;
    public async Task<ResponseDto<GetEmpresaResponseDto>> Handle(GetEmpresaRequest request, CancellationToken cancellationToken)
    {
        return await _empresaService.GetEmpresaAsync(request, cancellationToken);
    }
}