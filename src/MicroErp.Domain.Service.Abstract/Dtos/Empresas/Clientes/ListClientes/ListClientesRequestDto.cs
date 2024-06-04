using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.ListClientes;

public class ListClientesRequestDto: RequestPaginatedDto
{
    public string IdCliente { get; set; }
    public string Cnpj { get; set; }
    public string Responsavel { get; set; }
    public string Email { get; set; }
}