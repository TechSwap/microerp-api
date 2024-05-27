using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Ferramentas;

public class Ferramenta : BaseEntity
{
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public decimal ValorCompra { get; set; }
    public string Medida { get; set; }
    public string FabricanteId { get; set; }
    public string CodigoFabricante { get; set; }
    public DateTime DataCadastro { get; set; }
}
