using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemCompra;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.OrdemCompraCases.AddOrdemCompra;

public class AddOrdemCompraRequest: AddOrdemCompraRequestDto,  IRequest<ResponseDto<None>>
{
    
}