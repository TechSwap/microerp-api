using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;

public class ListFornecedoresRequestDto: RequestPaginatedDto
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
}