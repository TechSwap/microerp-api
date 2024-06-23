using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Fornecedores;

public class Fornecedor: BaseEntity
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? Fantasia { get; set; }
    public string? Contato1 { get; set; }
    public string? Contato2 { get; set; }
    public string? Email { get; set; }
    public string? Responsavel { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public bool Ativo { get; set; }
    
}