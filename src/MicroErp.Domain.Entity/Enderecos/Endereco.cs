using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Enderecos;

public class Endereco : BaseEntity
{
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Complemento { get; set; }
    public string? ClienteId { get; set; }
    public string? FornecedorId { get; set; }
    public string? UserId { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}
