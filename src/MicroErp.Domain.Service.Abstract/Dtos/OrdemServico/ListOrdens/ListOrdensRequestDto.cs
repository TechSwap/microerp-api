using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;

public class ListOrdensRequestDto: RequestPaginatedDto
{
    public string IdCliente { get; set; }
    public string Solicitante { get; set; }
    public DateTime? DataLancamento { get; set; }
}