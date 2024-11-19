using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Maquinas;

public class Maquina:BaseEntity
{
    public string NumeroSerie { get; set; }
    public string? Fabricante { get; set; }
    public string? Descricao { get; set; }
    public string? IdDepartamento { get; set; }
    public int Status { get; set; }
    public bool? Vendida { get; set; }
    public string? AtivoFixo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}