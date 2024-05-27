using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;

namespace MicroErp.Application.FornecedorCases.ListFornecedores;

public class ListFornecedoresHandler: IRequestHandler<ListFornecedoresRequest, ResponseDto<IEnumerable<ListFornecedoresResponseDto>>>
{
    private readonly IFornecedorService _fornecedorService;

    public ListFornecedoresHandler(IFornecedorService fornecedorService) => _fornecedorService = fornecedorService;
    
    public async Task<ResponseDto<IEnumerable<ListFornecedoresResponseDto>>> Handle(ListFornecedoresRequest request, CancellationToken cancellationToken)
    {
        return await _fornecedorService.ListFornecedoresAsync(request, cancellationToken);
    }
}