using MicroErp.Domain.Entity.Empresas;
using MicroErp.Domain.Service.Abstract.Dtos.Empresas.AddEmpresa;

namespace MicroErp.Domain.Service.Abstract.Mappers.Dtos.Empresas;

public class FornecedorMapper:BaseAutoMapper
{
    public FornecedorMapper()
    {
        CreateMap<AddEmpresaRequestDto, Empresa>()
            .BeforeMap((s, d) => d.Id = Guid.NewGuid().ToString().ToLower())
            .BeforeMap((s, d) => d.DataCadastro = DateTime.Now)
            .ReverseMap();
    }
}