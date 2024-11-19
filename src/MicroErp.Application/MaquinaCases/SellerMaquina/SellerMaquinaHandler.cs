using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.MaquinaCases.SellerMaquina;

public class SellerMaquinaHandler: IRequestHandler<SellerMaquinaRequest, ResponseDto<None>>
{
    private readonly IMaquinaService _maquinaService;

    public SellerMaquinaHandler(IMaquinaService maquinaService) => _maquinaService = maquinaService;
    public Task<ResponseDto<None>> Handle(SellerMaquinaRequest request, CancellationToken cancellationToken)
    {
        return _maquinaService.SellerMaquinaAsync(request, cancellationToken);
    }
}