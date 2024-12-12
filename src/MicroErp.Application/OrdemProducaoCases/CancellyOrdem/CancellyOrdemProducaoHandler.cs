using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemProducaoCases.CancellyOrdem;

public class CancellyOrdemProducaoHandler: IRequestHandler<CancellyOrdemProducaoRequest, ResponseDto<None>>
{
    private readonly IOrdemProducaoService _ordemProducaoService;
    public CancellyOrdemProducaoHandler(IOrdemProducaoService ordemProducaoService) => _ordemProducaoService = ordemProducaoService;
    
    public Task<ResponseDto<None>> Handle(CancellyOrdemProducaoRequest request, CancellationToken cancellationToken)
    {
        return _ordemProducaoService.CancellyOrdemAsync(request, cancellationToken);
    }
}