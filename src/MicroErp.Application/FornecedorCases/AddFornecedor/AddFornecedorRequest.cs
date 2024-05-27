using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.FornecedorCases.AddFornecedor;

public class AddFornecedorRequest: AddEmpresaRequestDto, IRequest<ResponseDto<None>>
{
    
}