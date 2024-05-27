using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Produto.ListProdutos;

public class ListProdutosRequestDto: RequestPaginatedDto
{
    public string Nome { get; set; }
    public string? Cliente { get; set; }
    public string? Fornecedor { get; set; }
    
}