using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.OrdemCompras;

public class DetalhesOrdemCompra: BaseEntity
{
    [ForeignKey("OrdemCompra")]
    public string IdOrdemCompra { get; set; }
    public int Item { get; set; }
    public int Quantidade { get; set; }
    public string Descricao { get; set; }
    public string Unidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}