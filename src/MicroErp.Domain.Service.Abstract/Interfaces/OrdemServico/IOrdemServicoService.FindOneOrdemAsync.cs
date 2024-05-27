using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;

public partial interface IOrdemServicoService
{
    Task<ResponseDto<FindOneOrdemResponseDto>> FindOneOrdemAsync(FindOneOrdemRequestDto request, CancellationToken cancellationToken);
}