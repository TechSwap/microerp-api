namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemCompra;

public class DetalheOrdemCompraRequestDto
{
    public int Item { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal { get; set; }
}