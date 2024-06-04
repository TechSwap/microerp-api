namespace MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;

public class FindOneDepartamentoResponseDto
{
    public string IdDepartamento { get; set; }
    public string Descricao { get; set; }
    public string Responsavel { get; set; }
    public string? CentroCusto { get; set; }
    public bool Status { get; set; }
    public DateTime DataCadastro { get; set; }
}