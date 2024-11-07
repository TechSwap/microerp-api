namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;

public class GetEmpresaResponseDto
{
    public string EmpresaId { get; set; }
    public string NomeFantasia { get; set; }
    public string RazaoSocial { get; set; }
    public string Cnpj { get; set; }
    public string InscricaoEstadual { get; set; }
    public string Contato1 { get; set; }
    public string Email { get; set; }
    public string Responsavel { get; set; }
    public string? DataFundacao { get; set; }
    public string? TipoEmpresa { get; set; } 
    public string? Logo { get; set; }
    public DateTime? DataCadastro { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Complemento { get; set; }
}