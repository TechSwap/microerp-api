using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.ListFuncionarios;

public class ListFuncionariosRequestDto: RequestPaginatedDto
{
    public string DepartamentoId { get; set; }
    public string Nome { get; set; }
    public string Funcao { get; set; }
}