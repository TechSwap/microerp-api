namespace MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;

public class ListFuncionariosResponseDto
{
    public string IdFuncionario { get; set; }
    public string Nome { get; set; }
    public int Codigo { get; set; }
    public string DepartamentoId { get; set; }
    public string Departamento { get; set; }
    public string CentroCusto { get; set; }
    public string Funcao { get; set; }
    public bool Ativo { get; set; }
}