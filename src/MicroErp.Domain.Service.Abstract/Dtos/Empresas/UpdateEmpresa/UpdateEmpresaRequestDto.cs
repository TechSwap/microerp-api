using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.UpdateEmpresa;

public class UpdateEmpresaRequestDto: RequestDto
{
    public string IdCliente { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? Responsavel { get; set; }
    public string? Fantasia { get; set; }
    public string? InscricaoEstadual { get; set; }
    public string? Contato1 { get; set; }
    public string? Contato2 { get; set; }
    public string? Email { get; set; }
    public bool? IsCliente { get; set; }
    public bool? IsFornecedor { get; set; }
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Numero { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }
    public string? Complemento { get; set; }
}