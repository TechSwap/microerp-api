namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;

public class ListOrdensProducaoResponseDto
{
    public int NumeroOp { get; set; }
    public string IdOrdemProducao { get; set; }
    public string IdCliente { get; set; }
    public string Cliente { get; set; }
    public string NumeroOs { get; set; }
    public int Status { get; set; }
    public int Itens { get; set; }
}