using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;
using MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.AddOrdem;

namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemServico.UpdateOrdem;

public class UpdateOrdemRequestDto: RequestDto
{
    public string IdOrdemServico { get; set; }
    public long NumeroOs { get; set; }
    public string IdCliente { get; set; }
    public string Solicitante { get; set; }
    public string NotaSaida { get; set; }
    public string NotaEntrada { get; set; }
    public string? Pedido { get; set; }
    public string? Orcamento { get; set; }
    public decimal ValorTotal { get; set; }
    public int Prazo { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataPrevisaoEntrega { get; set; }
    public DateTime DataEntrega { get; set; }
    public List<DetatlheOrdemServicoRequestDto> Detalhes { get; set; }
    
}