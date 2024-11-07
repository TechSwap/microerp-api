namespace MicroErp.Domain.Service.Abstract.Dtos.Orcamento.ListItensOrcamento;

public class ListItensOrcamentoRequestDto
{
    public int Itm { get; set; }
    public string Codigo { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
    public decimal Preco { get; set; }
    public decimal Total { get; set; }
}