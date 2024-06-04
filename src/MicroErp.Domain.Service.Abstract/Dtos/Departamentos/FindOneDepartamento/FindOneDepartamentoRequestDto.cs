using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Departamentos.FindOneDepartamento;

public class FindOneDepartamentoRequestDto: RequestDto
{
    public string IdDepartamento { get; set; }
}