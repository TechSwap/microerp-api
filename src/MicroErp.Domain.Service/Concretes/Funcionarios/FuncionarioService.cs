using AutoMapper;
using MicroErp.Domain.Entity.Funcionarios;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Funcionario;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Funcionarios;

public partial class FuncionarioService: BaseService, IFuncionarioService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly IBaseRepository<Funcionario> _repository;
    private readonly IBaseRepository<Entity.Departamentos.Departamento> _repositoryDepartamento;
    private readonly IUnitOfWork _unitOfWork;

    public FuncionarioService(
        IMapper mapper,
        ILogger<FuncionarioService> logger,
        IBaseRepository<Funcionario> repository,
        IBaseRepository<Entity.Departamentos.Departamento> repositoryDepartamento,
        IUnitOfWork unitOfWork,
        IConfiguration config) : base(logger)
    {
        _mapper = mapper;
        _config = config;
        _repository = repository;
        _repositoryDepartamento = repositoryDepartamento;
        _unitOfWork = unitOfWork;
    }
}