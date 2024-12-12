using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Operacao.AddOperacao;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OperacaoCases.AddOperacao;

public class AddOperacaoRequest: AddOperacaoRequestDto,  IRequest<ResponseDto<None>>
{
    
}