using MediatR;
using MicroErp.Application.OrdemProducaoCases.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemProducaoCases.StartOrdem;

public class StartOrdemProducaoHandler: IRequestHandler<StartOrdemProducaoRequest, ResponseDto<None>>
{
    private readonly IOrdemProducaoService _ordemProducaoService;
    public StartOrdemProducaoHandler(IOrdemProducaoService ordemProducaoService) => _ordemProducaoService = ordemProducaoService;
    public Task<ResponseDto<None>> Handle(StartOrdemProducaoRequest request, CancellationToken cancellationToken)
    {
        return _ordemProducaoService.StartOrdemAsync(request, cancellationToken);
    }
}