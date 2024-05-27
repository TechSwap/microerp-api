using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Empresas.Clientes.FindOne;

public class FindOneRequestDto: RequestDto
{
    public string? IdCliente { get; set; }
    public string? IdFornecedor { get; set; }
}