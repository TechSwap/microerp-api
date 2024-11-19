using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.UpdateMaquina;

public class UpdateMaquinaHandler: IRequestHandler<UpdateMaquinaRequest, ResponseDto<None>>
{
    private readonly IMaquinaService _maquinaService;

    public UpdateMaquinaHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<None>> Handle(UpdateMaquinaRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.UpdateMaquinaAsync(request, cancellationToken);
    }

}