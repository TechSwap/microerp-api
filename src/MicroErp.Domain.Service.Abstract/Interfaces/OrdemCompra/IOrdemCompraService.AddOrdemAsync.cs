using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemCompra;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemCompra;

public partial interface IOrdemCompraService
{
    Task<ResponseDto<None>> AddOrdemCompraAsync(AddOrdemCompraRequestDto request, CancellationToken cancellationToken);
}