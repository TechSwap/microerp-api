using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;

public partial interface IFornecedorService
{
    Task<ResponseDto<None>> AddFornecedorAsync(AddEmpresaRequestDto request, CancellationToken cancellationToken);
}
