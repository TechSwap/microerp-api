namespace MicroErp.Domain.Service.Abstract.Dtos.Departamentos.UpdateDepartamento;

public class UpdateDepartamentoRequestDto
{
    public string IdDepartamento { get; set; }
    public string Descricao { get; set; }
    public string Responsavel { get; set; }
    public string? CentroCusto { get; set; }
}