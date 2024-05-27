using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Funcionarios;

public class Funcionario : BaseEntity
{
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Setor { get; set; }
    public string CentroCusto { get; set; }
    public string Funcao { get; set; }
    public decimal ValorHora { get; set; }
    public DateTime DataCadastro { get; set; }
    
}