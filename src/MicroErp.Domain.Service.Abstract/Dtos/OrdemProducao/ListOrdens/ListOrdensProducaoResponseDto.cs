namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.ListOrdens;

public class ListOrdensProducaoResponseDto
{
    public int NumeroOp { get; set; }
    public string IdOrdemProducao { get; set; }
    public string IdCliente { get; set; }
    public string Cliente { get; set; }
    public long NumeroOs { get; set; }
    public int Status { get; set; }
    public int Itens { get; set; }
    public List<ItensDesc> ItensDesc { get; set; }
}

public class ItensDesc
{
    public string Id { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
    public int Status { get; set; }
}