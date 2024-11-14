namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.FindOneOrdem;

public class FindOneOrdemResponseDto
{
    public string IdOrdemServico { get; set; }
    public long NumeroOS { get; set; }
    public string IdCliente { get; set; }
    public string Cliente { get; set; }
    public string Solicitante { get; set; }
    public string? NotaSaida { get; set; }
    public string? NotaEntrada { get; set; }
    public string? Pedido { get; set; }
    public string? Orcamento { get; set; }
    public decimal ValorTotal { get; set; }
    public int Prazo { get; set; }
    public DateTime? DataPrevisaoEntrega { get; set; }
    public DateTime? Lancamento { get; set; }
    public DateTime? DataEntrega { get; set; }
    public List<DetalheOrdemServico> DetalheOrdemServicos { get; set; }
}

public class DetalheOrdemServico 
{
    public string IdDetalhesOrdemServico { get; set; }
    public string OrdemServicoId { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
}
