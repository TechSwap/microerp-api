using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Produto.FindOneProduto;

public class FindOneProdutoRequestDto: RequestDto
{
    public string IdProduto { get; set; }
}