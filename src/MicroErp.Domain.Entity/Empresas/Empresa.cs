using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Empresas;

public class Empresa : BaseEntity
{
    public string? NomeFantasia { get; set; }
    public string? RazaoSocial { get; set; }
    public string? Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? Contato1 { get; set; }
    public string? Email { get; set; }
    public string? Responsavel { get; set; }
    public DateTime? DataFundacao { get; set; }
    public string? TipoEmpresa { get; set; }
    public string? Logo { get; set; }
    public DateTime DataCadastro { get; set; }      
}