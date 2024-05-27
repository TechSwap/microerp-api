using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.Clientes;

namespace MicroErp.Domain.Entity.OrdemServicos;

public class OrdemServico: BaseEntity
{
    public OrdemServico()
    {
        DetalhesOrdemServico = new HashSet<DetalhesOrdemServico>();
    }
    
    public long NumeroOS { get; set; }
    [ForeignKey("Cliente")]
    public string IdCliente { get; set; }
    public string Solicitante { get; set; }
    public string? NotaEntrada { get; set; }
    public string? NotaSaida { get; set; }
    public string? Pedido { get; set; }
    public string? Orcamento { get; set; }
    public decimal? ValorTotal { get; set; }
    public int? Prazo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataPrevisaoEntrega { get; set; }
    public DateTime? DataEntrega { get; set; }

    public virtual Cliente Cliente { get; set; }
    public virtual ICollection<DetalhesOrdemServico> DetalhesOrdemServico { get; set; }
}