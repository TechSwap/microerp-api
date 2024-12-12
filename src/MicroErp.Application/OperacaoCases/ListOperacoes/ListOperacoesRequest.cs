using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;

namespace MicroErp.Application.OperacaoCases.ListOperacoes;

public class ListOperacoesRequest: ListOperacoesRequestDto,  IRequest<ResponseDto<IEnumerable<ListOperacoesResponseDto>>>
{
    
}