using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Fabricantes;

public class Fabricante : BaseEntity
{
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
}
