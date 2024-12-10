using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;

namespace MicroErp.Application.OrdemProducaoCases.FindOneOrdem;

public class FindOneOrdemProducaoHandler: IRequestHandler<FindOneOrdemProducaoRequest, ResponseDto<FindOneOdermProducaoResponseDto>>
{
    private readonly IOrdemProducaoService _ordemProducaoService;

    public FindOneOrdemProducaoHandler(IOrdemProducaoService ordemProducaoService) => _ordemProducaoService = ordemProducaoService;
    public Task<ResponseDto<FindOneOdermProducaoResponseDto>> Handle(FindOneOrdemProducaoRequest request, CancellationToken cancellationToken)
    {
        return _ordemProducaoService.FindOneOrdemAsync(request, cancellationToken);
    }
}