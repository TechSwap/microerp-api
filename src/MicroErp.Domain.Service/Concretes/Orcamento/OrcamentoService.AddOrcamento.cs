using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Orcamento.AddOrcamento;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Concretes.Orcamento;

public partial class OrcamentoService
{
    public Task<ResponseDto<None>> AddOrcamentoAsync(AddOrcamentoRequestDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}