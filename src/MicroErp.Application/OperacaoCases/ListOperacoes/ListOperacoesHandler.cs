using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;
using MicroErp.Domain.Service.Abstract.Interfaces.Operacao;

namespace MicroErp.Application.OperacaoCases.ListOperacoes;

public class ListOperacoesHandler: IRequestHandler<ListOperacoesRequest, ResponseDto<IEnumerable<ListOperacoesResponseDto>>>
{
    private readonly IOperacaoService _operacaoService;

    public ListOperacoesHandler(IOperacaoService operacaoService) => _operacaoService = operacaoService;

    public Task<ResponseDto<IEnumerable<ListOperacoesResponseDto>>> Handle(ListOperacoesRequest request, CancellationToken cancellationToken)
    {
        return _operacaoService.ListOperacoesAsync(request, cancellationToken);
    }
}