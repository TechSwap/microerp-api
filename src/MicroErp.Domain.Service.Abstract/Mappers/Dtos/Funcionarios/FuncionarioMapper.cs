using MicroErp.Domain.Entity.Funcionarios;
using MicroErp.Domain.Service.Abstract.Dtos.Funcionarios.AddFuncionario;

namespace MicroErp.Domain.Service.Abstract.Mappers.Dtos.Funcionarios;

public class FuncionarioMapper:BaseAutoMapper
{
    public FuncionarioMapper()
    {
        CreateMap<AddFuncionarioRequestDto, Funcionario>()
            .BeforeMap((s, d) => d.Id = Guid.NewGuid().ToString().ToLower())
            .BeforeMap((s, d) => d.DataCadastro = DateTime.Now)
            .ReverseMap();
    }
}