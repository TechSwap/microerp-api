using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.DeleteMaquina;

public class DeleteMaquinaHandler: IRequestHandler<DeleteMaquinaRequest, ResponseDto<None>>
{
    private readonly IMaquinaService _maquinaService;
    public DeleteMaquinaHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<None>> Handle(DeleteMaquinaRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.DeleteMaquinaAsync(request, cancellationToken);
    }
}