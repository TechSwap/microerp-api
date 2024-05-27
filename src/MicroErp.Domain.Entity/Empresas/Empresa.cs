using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Empresas;

public class Empresa : BaseEntity
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? Contato1 { get; set; }
    public string? Contato2 { get; set; }
    public string? Email { get; set; }
    public DateTime DataCadastro { get; set; }
    public bool Ativo { get; set; }
}