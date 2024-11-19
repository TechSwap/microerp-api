using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Maquinas.ListMaquinas;

public class ListMaquinasRequestDto: RequestPaginatedDto
{
    public string IdDepartamento { get; set; }
    public string NumeroSerie { get; set; }
    public string Fabricante { get; set; }
}