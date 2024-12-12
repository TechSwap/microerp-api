using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Operacao.ListOperacoes;

public class ListOperacoesRequestDto: RequestPaginatedDto
{
    public string IdDepartamento { get; set; }
    public string Responsavel { get; set; }
}