using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Departamentos;

public class Departamento: BaseEntity
{
    public string Descricao { get; set; }
    public string Responsavel { get; set; }
    public string? CentroCusto { get; set; }
    public bool Status { get; set; }
    public DateTime DataCadastro { get; set; }
}