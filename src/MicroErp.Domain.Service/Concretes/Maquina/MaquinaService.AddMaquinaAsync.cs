using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Maquinas.AddMaquina;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService 
{
    public Task<ResponseDto<None>> AddMaquinaAsync(AddMaquinaRequestDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}