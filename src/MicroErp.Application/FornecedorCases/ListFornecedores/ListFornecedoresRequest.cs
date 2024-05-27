using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;

namespace MicroErp.Application.FornecedorCases.ListFornecedores;

public class ListFornecedoresRequest: ListFornecedoresRequestDto, IRequest<ResponseDto<IEnumerable<ListFornecedoresResponseDto>>>
{
    
}