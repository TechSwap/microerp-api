using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Produtos;

public class Produto : BaseEntity
{
    public long Codigo { get; set; }
    public string Descricao { get; set; }
    public string Unidade { get; set; }
    public decimal? PrecoCusto { get; set; }
    public decimal? PrecoVenda { get; set; }
    public string? CodigoBarras { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public string? Observacao { get; set; }
    public string? FornecedorId { get; set; }
    public string? ClienteId { get; set; }
}
