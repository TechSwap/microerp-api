using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Orcamento.AddOrcamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Orcamento;

public interface IOrcamentoService
{
    Task<ResponseDto<None>> AddOrcamentoAsync(AddOrcamentoRequestDto request, CancellationToken cancellationToken);
}