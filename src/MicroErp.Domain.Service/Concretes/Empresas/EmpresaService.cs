using AutoMapper;
using MicroErp.Domain.Entity.Empresas;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Service.Abstract.Interfaces.Empresa;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Empresas;

public partial class EmpresaService : BaseService, IEmpresaService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Empresa> _repository;   
    private readonly IBaseRepository<Endereco> _repositoryEndereco;   

    public EmpresaService(ILogger<EmpresaService> logger,
        IMapper mapper,
        IBaseRepository<Endereco> repositoryEndereco,            
        IBaseRepository<Empresa> repository) : base(logger)
    {
        _mapper = mapper;
        _repository = repository;
        _repositoryEndereco = repositoryEndereco;
    }
}