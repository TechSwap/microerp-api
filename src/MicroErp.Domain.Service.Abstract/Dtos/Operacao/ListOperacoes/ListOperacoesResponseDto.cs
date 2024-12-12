namespace MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;

public class ListOperacoesResponseDto
{
    public string IdOperacao { get; set; }
    public string Descricao { get; set; }
    public string IdDepartamento { get; set; }
    public string Departamento { get; set; }
    public string Responsavel { get; set; }
    public bool Status { get; set; }
}