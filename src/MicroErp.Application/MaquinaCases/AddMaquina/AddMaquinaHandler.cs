using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.AddMaquina;

public class AddMaquinaHandler: IRequestHandler<AddMaquinaRequest, ResponseDto<None>>
{
    private readonly IMaquinaService _maquinaService;

    public AddMaquinaHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<None>> Handle(AddMaquinaRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.AddMaquinaAsync(request, cancellationToken);
    }
}