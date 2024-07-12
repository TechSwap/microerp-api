namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemCompra;

public class AddOrdemCompraRequestDto
{
    public long NumeroPedido { get; set; }
    public string Solicitante { get; set; }
    public string IdDepartamento { get; set; }
    public string IdFornecedor { get; set; }
    public DateTime DataPedido { get; set; }
    public decimal ValorTotal { get; set; }
    public List<DetalheOrdemCompraRequestDto> Detalhes { get; set; }
}