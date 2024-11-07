using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Orcamentos;

public class Orcamento: BaseEntity
{
    public int Numero { get; set; }
    [ForeignKey("Cliente")]
    public string IdCliente { get; set; }
    public DateTime DataEmissao { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Desconto { get; set; }
    public decimal Frete { get; set; }
    public decimal Total { get; set; }
    public string Observacao { get; set; }
}