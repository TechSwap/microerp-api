using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.AddFornecedor;

public class AddFornecedorHandler: IRequestHandler<AddFornecedorRequest, ResponseDto<None>>
{
    private readonly IFornecedorService _fornecedorService;
    public AddFornecedorHandler(IFornecedorService fornecedorService) => _fornecedorService = fornecedorService;
    
    public async Task<ResponseDto<None>> Handle(AddFornecedorRequest request, CancellationToken cancellationToken)
    {
        return await _fornecedorService.AddFornecedorAsync(request, cancellationToken);
    }
}