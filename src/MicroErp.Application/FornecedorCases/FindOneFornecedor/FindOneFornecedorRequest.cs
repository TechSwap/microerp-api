using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;

namespace MicroErp.Application.FornecedorCases.FindOneFornecedor;

public class FindOneFornecedorRequest: FindOneRequestDto, IRequest<ResponseDto<FindOneResponseDto>>
{
    
}