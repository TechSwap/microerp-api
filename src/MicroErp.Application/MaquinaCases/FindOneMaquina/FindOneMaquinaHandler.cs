using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.FindOneMaquina;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;

namespace MicroErp.Application.MaquinaCases.FindOneMaquina;

public class FindOneMaquinaHandler: IRequestHandler<FindOneMaquinaRequest, ResponseDto<FindOneMaquinaResponseDto>>
{
    private readonly IMaquinaService _maquinaService;
    public FindOneMaquinaHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<FindOneMaquinaResponseDto>> Handle(FindOneMaquinaRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.FindOneMaquinaAsync(request, cancellationToken);
    }
}