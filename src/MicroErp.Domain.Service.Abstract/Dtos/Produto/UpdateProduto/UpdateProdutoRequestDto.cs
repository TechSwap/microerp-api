using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Produto.UpdateProduto;

public class UpdateProdutoRequestDto: RequestDto
{
    public string IdProduto { get; set; }
    public string Descricao { get; set; }
    public string Unidade { get; set; }
    public decimal? PrecoCusto { get; set; }
    public decimal? PrecoVenda { get; set; }
    public string? Observacao { get; set; }
}