using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;

namespace MicroErp.Application.OrdemProducaoCases.ListOrdens;

public class ListOrdensProducaoHandler: IRequestHandler<ListOrdensProducaoRequest, ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>>
{
    private readonly IOrdemProducaoService _ordemProducaoService;
    public ListOrdensProducaoHandler(IOrdemProducaoService ordemProducaoService) => _ordemProducaoService = ordemProducaoService;
    public Task<ResponseDto<IEnumerable<ListOrdensProducaoResponseDto>>> Handle(ListOrdensProducaoRequest producaoRequest, CancellationToken cancellationToken)
    {
        return _ordemProducaoService.ListOrdensAsync(producaoRequest, cancellationToken);
    }
}