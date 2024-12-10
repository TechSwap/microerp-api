using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.AddOrdem;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;

public partial interface IOrdemProducaoService
{
    Task<ResponseDto<FindOneOdermProducaoResponseDto>> FindOneOrdemAsync(FindOneOrdemProducaoRequestDto request, CancellationToken cancellationToken);
}