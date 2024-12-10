namespace MicroErp.Domain.Service.Abstract.Dtos.OrdemProducao.FindOne;

public class FindOneOrdemProducaoRequestDto
{
    public string  IdOrdemProducao { get; set; }
    public List<DetalhesFindOneProducaoRequestDto>? Detalhes { get; set; }
}

public class DetalhesFindOneProducaoRequestDto
{
    public string? IdOrdemProducaoDetalhe { get; set; }
    public string? IdMaquina { get; set; }
    public string? IdFuncionario { get; set; }
    public int? HorasTrabalhadas { get; set; }
}