using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Orcamentos;

public class DetalheOrcamento: BaseEntity
{
    [ForeignKey("Orcamento")]
    public string IdOrcamento { get; set; }
    public int Itm { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
    public decimal Preco { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
}