namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;

public class ListClientesResponseDto
{
    public string IdCliente { get; set; }
    public string Nome { get; set; }
    public string Fantasia { get; set; }
    public string CNPJ { get; set; }
    public string Contato1 { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
}