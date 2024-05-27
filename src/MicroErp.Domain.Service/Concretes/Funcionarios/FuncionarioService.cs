using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService: BaseService, IFuncionarioService
{
    private readonly IConfiguration _config;

    public FuncionarioService(ILogger<FuncionarioService> logger,
        IConfiguration config) : base(logger)
    {
        _config = config;
    }
}