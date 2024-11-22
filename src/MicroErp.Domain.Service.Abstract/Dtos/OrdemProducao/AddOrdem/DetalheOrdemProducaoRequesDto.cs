namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.AddOrdem;

public class DetalheOrdemProducaoRequesDto
{
    public string? IdDetalhesOrdemProducao { get; set; }
    public string? IdOrdemProducao { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
    public DateTime? PrazoEntrega { get; set; }
    public DateTime? DataEntrega { get; set; }
}