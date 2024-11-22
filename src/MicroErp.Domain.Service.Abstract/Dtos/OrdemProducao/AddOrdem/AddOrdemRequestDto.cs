namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.AddOrdem;

public class AddOrdemRequestDto
{
    public string? IdOrdemProducao { get; set; }
    public int? NumeroOp { get; set; }
    public string? IdOrdemServico { get; set; }
    public string IdCliente { get; set; }
    public int Prazo { get; set; }
    public int Status { get; set; }
    public List<DetalheOrdemProducaoRequesDto> Detalhes { get; set; }
}