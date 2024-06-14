namespace MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.FindOneFuncionario;

public class FindOneFuncionarioResponseDto
{
    public string IdFuncionario { get; set; }
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public string DepartamentoId { get; set; }
    public string Departamento { get; set; }
    public string CentroCusto { get; set; }
    public string Funcao { get; set; }
    public decimal ValorHora { get; set; }
    public bool Ativo { get; set; }
    public DateTime DataCadastro { get; set; }
}