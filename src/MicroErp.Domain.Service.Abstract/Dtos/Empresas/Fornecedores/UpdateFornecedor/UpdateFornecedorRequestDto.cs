namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.UpdateFornecedor;

public class UpdateFornecedorRequestDto
{
    public string IdFornecedor { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? Contato1 { get; set; }
    public string? Contato2 { get; set; }
    public string? Email { get; set; }
    public bool? IsCliente { get; set; }
    public bool? IsFornecedor { get; set; }
    public string? Cep { get; set; }
    public string? Endereco { get; set; }
    public string? Bairro { get; set; }
    public string? Numero { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
}