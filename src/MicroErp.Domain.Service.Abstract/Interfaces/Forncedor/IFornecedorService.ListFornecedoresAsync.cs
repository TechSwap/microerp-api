using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;

public partial interface IFornecedorService
{
    Task<ResponseDto<IEnumerable<ListFornecedoresResponseDto>>> ListFornecedoresAsync(ListFornecedoresRequestDto request, CancellationToken cancellationToken);
}
