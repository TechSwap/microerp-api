using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.ActiveMaquina;

public class ActiveMaquinaHandler: IRequestHandler<ActiveMaquinaRequest, ResponseDto<None>>
{
    private readonly IMaquinaService _maquinaService;

    public ActiveMaquinaHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<None>> Handle(ActiveMaquinaRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.ActiveMaquinaAsync(request, cancellationToken);
    }
}