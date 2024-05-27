using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Produto.AddProduto;

public class AddProdutoRequestDto: RequestDto
{
    public string Descricao { get; set; }
    public string Unidade { get; set; }
    public decimal? PrecoCusto { get; set; }
    public decimal? PrecoVenda { get; set; }
    public string? Observacao { get; set; }
    public string? FornecedorId { get; set; }
    public string? ClienteId { get; set; }
    public bool? IsCliente { get; set; }
    public bool? IsFornecedor { get; set; }
}