using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.OrdemProducao;

public class DetalhesOrdemProducao: BaseEntity
{
    [ForeignKey("OrdemProducao")]
    public string IdOrdemProducao { get; set; }
    public int Quantidade { get; set; }
    public string Descricao { get; set; }
    public string Unidade { get; set; }
    public DateTime? PrazoEntrega { get; set; }
    public DateTime? DataEntrega { get; set; }
    public DateTime? DataInicializacao { get; set; }
    public DateTime? DataFinalizacao { get; set; }
    public string? IdFuncionario { get; set; }
    public string? IdMaquina { get; set; }
    public int? HorasTrabalhadas { get; set; }
    public int? Status { get; set; }
}