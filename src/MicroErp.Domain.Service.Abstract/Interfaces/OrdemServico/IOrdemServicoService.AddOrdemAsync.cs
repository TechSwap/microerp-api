using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

public partial interface IOrdemServicoService
{
    Task<ResponseDto<None>> AddOrdemAsync(AddOrdemRequestDto request, CancellationToken cancellationToken);
}