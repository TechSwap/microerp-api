using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Departamentos.ListDepartamentos;

public class ListDepartamentosRequestDto: RequestPaginatedDto
{
    public string IdDepartamento { get; set; }
    public string Responsavel { get; set; }
    public string CentroCusto { get; set; }
}