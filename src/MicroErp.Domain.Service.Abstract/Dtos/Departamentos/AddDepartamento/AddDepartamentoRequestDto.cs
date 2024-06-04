namespace MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;

public class AddDepartamentoRequestDto
{
    public string Descricao { get; set; }
    public string Responsavel { get; set; }
    public string? CentroCusto { get; set; }
}