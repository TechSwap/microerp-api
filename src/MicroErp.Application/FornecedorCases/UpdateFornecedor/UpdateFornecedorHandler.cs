using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.UpdateFornecedor;

public class UpdateFornecedorHandler: IRequestHandler<UpdateFornecedorRequest, ResponseDto<None>>
{
    private readonly IFornecedorService _fornecedorService;

    public UpdateFornecedorHandler(IFornecedorService fornecedorService) => _fornecedorService = fornecedorService;
    
    public async Task<ResponseDto<None>> Handle(UpdateFornecedorRequest request, CancellationToken cancellationToken)
    {
        return await _fornecedorService.UpdateFornecedorAsync(request, cancellationToken);
    }
}