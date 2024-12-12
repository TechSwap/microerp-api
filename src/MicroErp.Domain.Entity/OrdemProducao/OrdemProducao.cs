using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;
using MicroErp.Domain.Entity.Clientes;

namespace MicroErp.Domain.Entity.OrdemProducao;

public class OrdemProducao: BaseEntity
{
    public string? IdOrdemServico { get; set; }
    public string IdCliente { get; set; }
    public int NumeroOp { get; set; }
    public int Prazo { get; set; }
    public int Status { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataCancelamento { get; set; }
    public string? MotivoCancelamento { get; set; }
}