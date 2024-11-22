using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemProducaoCases.AddOrdem;

public class AddOrdemProducaoHandler: IRequestHandler<AddOrdemProducaoRequest, ResponseDto<None>>
{
    private readonly IOrdemProducaoService _ordemProducaoService;
    public AddOrdemProducaoHandler(IOrdemProducaoService ordemProducaoService) => _ordemProducaoService = ordemProducaoService;
    public Task<ResponseDto<None>> Handle(AddOrdemProducaoRequest producaoRequest, CancellationToken cancellationToken)
    {
        return _ordemProducaoService.AddOrdemAsync(producaoRequest, cancellationToken);
    }
}