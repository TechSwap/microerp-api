using System.ComponentModel.DataAnnotations.Schema;
using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Operacoes;

public class Operacao: BaseEntity
{
    [ForeignKey("Departamento")]
    public string IdDepartamento { get; set; }
    public string Descricao { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}