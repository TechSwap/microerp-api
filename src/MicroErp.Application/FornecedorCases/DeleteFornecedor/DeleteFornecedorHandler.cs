using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.DeleteFornecedor;

public class DeleteFornecedorHandler: IRequestHandler<DeleteFornecedorRequest, ResponseDto<None>>
{
    private readonly IFornecedorService _fornecedorService;
    public DeleteFornecedorHandler(IFornecedorService fornecedorService) => _fornecedorService = fornecedorService;
    public async Task<ResponseDto<None>> Handle(DeleteFornecedorRequest request, CancellationToken cancellationToken)
    {
        return await _fornecedorService.DeleteFornecedorAsync(request, cancellationToken);
    }
}