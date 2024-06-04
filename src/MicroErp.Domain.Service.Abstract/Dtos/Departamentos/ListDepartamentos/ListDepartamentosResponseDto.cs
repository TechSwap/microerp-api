namespace MicroErp.Domain.Service.Abstract.Dtos.Departamentos.ListDepartamentos;

public class ListDepartamentosResponseDto
{
    public string IdDepartamento { get; set; }
    public string Descricao { get; set; }
    public string Responsavel { get; set; }
    public string? CentroCusto { get; set; }
    public bool Status { get; set; }
}