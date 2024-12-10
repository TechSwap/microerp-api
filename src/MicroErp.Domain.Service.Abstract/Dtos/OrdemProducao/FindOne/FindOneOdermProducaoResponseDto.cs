namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;

public class FindOneOdermProducaoResponseDto
{
    public string IdOrdemProducao { get; set; }
    public string? IdOrdemServico { get; set; }
    public int NumeroOp { get; set; }
    public string IdCliente { get; set; }
    public string? Cliente { get; set; }
    public int Prazo { get; set; }
    public string Status { get; set; }
    public List<DetalhesOrdemProducaoResponseDto> Detalhes { get; set; }
}

public class DetalhesOrdemProducaoResponseDto
{
    public string IdDetalhesOrdemProducao { get; set; }
    public string IdOrdemProducao { get; set; }
    public string Descricao { get; set; }
    public decimal Quantidade { get; set; }
    public string Unidade { get; set; }
    public DateTime PrazoEntrega { get; set; }
    public DateTime? DataEntrega { get; set; }
}