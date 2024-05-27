using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.Produtos;

namespace MicroErp.Domain.Entity.OrdemServicos;

public class DetalhesOrdemServico: BaseEntity
{
    [ForeignKey("OrdemServico")]
    public string OrdemServicoId { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
    public DateTime? PrazoEntrega { get; set; }
    public virtual OrdemServico OrdemServico { get; set; }
}