using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.ActiveFornecedor;

public class ActiveFornecedorHandler: IRequestHandler<ActiveFornecedorRequest, ResponseDto<None>>
{
    private readonly IFornecedorService _fornecedorService;

    public ActiveFornecedorHandler(IFornecedorService fornecedorService) => fornecedorService = _fornecedorService;
    
    public async Task<ResponseDto<None>> Handle(ActiveFornecedorRequest request, CancellationToken cancellationToken)
    {
        return await _fornecedorService.ActiveFornecedorAsync(request, cancellationToken);
    }
}