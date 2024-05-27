namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;

public class DetatlheOrdemServicoRequestDto
{
    public string? IdDetalhesOrdemServico { get; set; }
    public string? OrdemServicoId { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }
    public int Quantidade { get; set; }
    public string Unidade { get; set; }
}