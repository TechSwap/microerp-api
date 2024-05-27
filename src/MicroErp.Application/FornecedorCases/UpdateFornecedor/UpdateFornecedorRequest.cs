using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.UpdateFornecedor;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.UpdateFornecedor;

public class UpdateFornecedorRequest: UpdateFornecedorRequestDto, IRequest<ResponseDto<None>>
{
    
}