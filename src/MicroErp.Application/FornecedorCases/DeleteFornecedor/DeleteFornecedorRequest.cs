using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.DeleteFornecedor;

public class DeleteFornecedorRequest: FindOneRequestDto, IRequest<ResponseDto<None>>
{
    
}