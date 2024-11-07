using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.OrdemCompras;

public class OrdemCompra: BaseEntity
{
    [ForeignKey("Fornecedor")]
    public string IdFornecedor { get; set; }
    [ForeignKey("Departamento")]
    public string IdDepartamento { get; set; }
    public string Solicitante { get; set; }
    public DateTime DataPedido { get; set; }
    public long NumeroPedido { get; set; }
    public string DigitadoPor { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public decimal? ValorTotal { get; set; }
    public string? IdStatus { get; set; }
    public bool Ativo { get; set; }
}