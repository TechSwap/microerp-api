using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.CancellyOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;

public partial interface IOrdemProducaoService
{
    Task<ResponseDto<None>> CancellyOrdemAsync(CancellyOrdemRequestDto request, CancellationToken cancellationToken);
}