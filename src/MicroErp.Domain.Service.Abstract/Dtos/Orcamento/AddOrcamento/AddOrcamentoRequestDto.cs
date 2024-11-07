using MicroErp.Domain.Service.Abstract.Dtos.Orcamento.ListItensOrcamento;

namespace MicroErp.Domain.Service.Abstract.Dtos.Orcamento.AddOrcamento;

public class AddOrcamentoRequestDto
{
    public string IdCliente { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Desconto { get; set; }
    public decimal Frete { get; set; }
    public decimal Total { get; set; }
    public string Observacao { get; set; }
    public List<ListItensOrcamentoRequestDto> Itens { get; set; }
}