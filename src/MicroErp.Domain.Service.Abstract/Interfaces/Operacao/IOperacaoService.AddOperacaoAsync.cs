using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.AddOperacao;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Operacao;

public partial interface IOperacaoService
{
    Task<ResponseDto<None>> AddOperacaoAsync(AddOperacaoRequestDto request, CancellationToken cancellationToken);
}