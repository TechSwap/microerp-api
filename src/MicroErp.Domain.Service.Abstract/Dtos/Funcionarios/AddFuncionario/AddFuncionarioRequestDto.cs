using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;

public class AddFuncionarioRequestDto: RequestDto
{
    public string Nome { get; set; }
    public string? Setor { get; set; }
    public string? CentroCusto { get; set; }
    public string? Funcao { get; set; }
    public decimal ValorHora { get; set; }
}