using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Operacao;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OperacaoCases.AddOperacao;

public class AddOperacaoHandler: IRequestHandler<AddOperacaoRequest, ResponseDto<None>>
{
    private readonly IOperacaoService _operacaoService;

    public AddOperacaoHandler(IOperacaoService operacaoService) => _operacaoService = operacaoService;

    public Task<ResponseDto<None>> Handle(AddOperacaoRequest request, CancellationToken cancellationToken)
    {
        return _operacaoService.AddOperacaoAsync(request, cancellationToken);
    }
}