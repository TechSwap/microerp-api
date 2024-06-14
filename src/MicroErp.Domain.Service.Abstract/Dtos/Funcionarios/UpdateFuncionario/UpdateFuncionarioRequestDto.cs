namespace MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.UpdateFuncionario;

public class UpdateFuncionarioRequestDto
{
    public string IdFuncionario { get; set; }
    public string Nome { get; set; }
    public string? DepartamentoId { get; set; }
    public string? CentroCusto { get; set; }
    public int Codigo { get; set; }
    public string? Funcao { get; set; }
    public decimal ValorHora { get; set; }
}