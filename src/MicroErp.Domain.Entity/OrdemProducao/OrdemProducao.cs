using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.OrdemProducao;

public class OrdemProducao: BaseEntity
{
    public string? IdOrdemServico { get; set; }
    [ForeignKey("Clientes")]
    public string IdCliente { get; set; }
    public long NumeroOp { get; set; }
    public int Prazo { get; set; }
    public int Status { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}