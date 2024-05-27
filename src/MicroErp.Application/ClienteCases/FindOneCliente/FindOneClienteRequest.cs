using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;

namespace MicroErp.Application.ClienteCases.FindOneCliente;

public class FindOneClienteRequest: FindOneRequestDto, IRequest<ResponseDto<FindOneResponseDto>>
{
    
}