using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.AddOrdem;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemProducaoCases.AddOrdem;

public class AddOrdemProducaoRequest: AddOrdemRequestDto,  IRequest<ResponseDto<None>>
{
    
}