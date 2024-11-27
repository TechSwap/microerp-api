using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;

public class ListOrdensProducaoRequestDto: RequestPaginatedDto 
{
    public string IdCliente { get; set; }
    public int Status { get; set; }
}