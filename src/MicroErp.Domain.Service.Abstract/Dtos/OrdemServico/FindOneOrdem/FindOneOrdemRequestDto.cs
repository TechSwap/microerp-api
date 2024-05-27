using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;

public class FindOneOrdemRequestDto: RequestDto
{
    public string IdOrdemServico { get; set; }
}