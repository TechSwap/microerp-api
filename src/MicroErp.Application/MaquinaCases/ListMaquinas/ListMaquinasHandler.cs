using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;

namespace MicroErp.Application.MaquinaCases.ListMaquinas;

public class ListMaquinasHandler: IRequestHandler<ListMaquinasRequest, ResponseDto<IEnumerable<ListMaquinasResponseDto>>>
{
    private readonly IMaquinaService _maquinaService;

    public ListMaquinasHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<IEnumerable<ListMaquinasResponseDto>>> Handle(ListMaquinasRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.ListMaquinasAsync(request, cancellationToken);
    }
}