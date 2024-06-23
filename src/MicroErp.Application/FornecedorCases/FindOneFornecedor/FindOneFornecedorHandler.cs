using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;

namespace MicroErp.Application.FornecedorCases.FindOneFornecedor;

public class FindOneFornecedorHandler: IRequestHandler<FindOneFornecedorRequest, ResponseDto<FindOneResponseDto>>
{
    private readonly IFornecedorService _fornecedorService;
    public FindOneFornecedorHandler(IFornecedorService fornecedorService) => _fornecedorService = fornecedorService;
    public async Task<ResponseDto<FindOneResponseDto>> Handle(FindOneFornecedorRequest request, CancellationToken cancellationToken)
    {
        return await _fornecedorService.FindOneFornecedorAsync(request, cancellationToken);
    }
}