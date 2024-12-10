namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.ListOrdens;

public class ListOrdensResponseDto
{
    public string IdOrdemServico { get; set; }
    public long NumeroOS { get; set; }
    public string IdCliente { get; set; }
    public string Cliente { get; set; }
    public string Solicitante { get; set; }
    public string NotaSaida { get; set; }
    public decimal ValorTotal { get; set; }
    public int Itens { get; set; }
    public int? Status { get; set; }
    public DateTime DataLancamento { get; set; }
    public DateTime DataPrevisaoEntrega { get; set; }
}