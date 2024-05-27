using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.UpdateEmpresa;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.ClienteCases.UpdateCliente;

public class UpdateClienteRequest: UpdateEmpresaRequestDto, IRequest<ResponseDto<None>>
{
    
}