using AutoMapper;
using MicroErp.Domain.Entity.Empresas;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Empresa;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Empresas;

public partial class EmpresaService : BaseService, IEmpresaService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Empresa> _repository;
    private readonly IBaseRepository<Empresa> _repositoryCliente;
    private readonly IBaseRepository<Empresa> _repositoryFornecedor;
    private readonly IBaseRepository<Endereco> _repositoryEndereco;
    private readonly IUnitOfWork _unitOfWork;

    public EmpresaService(ILogger<EmpresaService> logger,
        IBaseRepository<Endereco> repositoryEndereco,
        IBaseRepository<Empresa> repositoryCliente,
        IBaseRepository<Empresa> repositoryFornecedor,
        IUnitOfWork unitOfWork,
        IBaseRepository<Empresa> repository) : base(logger)
    {
        _repository = repository;
        _repositoryEndereco = repositoryEndereco;
        _repositoryCliente = repositoryCliente;
        _repositoryFornecedor = repositoryFornecedor;
        _unitOfWork = unitOfWork;
    }
}