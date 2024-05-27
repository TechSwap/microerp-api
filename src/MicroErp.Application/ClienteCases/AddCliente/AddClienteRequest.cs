using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ClienteCases.AddCliente;

public class AddClienteRequest: AddEmpresaRequestDto, IRequest<ResponseDto<None>>
{
    
}