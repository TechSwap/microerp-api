using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;

public class AddFuncionarioRequestDto: RequestDto
{
    public string Nome { get; set; }
    public string? DepartamentoId { get; set; }
    public string? CentroCusto { get; set; }
    public int Codigo { get; set; }
    public string? Funcao { get; set; }
    public decimal ValorHora { get; set; }
}