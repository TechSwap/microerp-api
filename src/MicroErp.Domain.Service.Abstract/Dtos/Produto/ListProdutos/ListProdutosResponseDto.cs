namespace MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;

public class ListProdutosResponseDto
{
    public string IdProduto { get; set; }
    public long Codigo { get; set; }
    public string Descricao { get; set; }
    public string Unidade { get; set; }
    public bool Ativo { get; set; }
    public decimal? PrecoVenda { get; set; }
    public decimal? PrecoCusto { get; set; }
    public string? FornecedorId { get; set; }
    public string? ClienteId { get; set; }
}