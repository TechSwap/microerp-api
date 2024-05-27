namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.Fornecedores.ListFornecedores;

public class ListFornecedoresResponseDto
{
    public string IdFornecedor { get; set; }
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Contato1 { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
}