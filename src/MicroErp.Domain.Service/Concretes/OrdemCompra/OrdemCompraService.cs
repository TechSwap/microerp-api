using AutoMapper;
using MicroErp.Domain.Entity.OrdemCompras;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemCompra;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemCompra;

public partial class OrdemCompraService: BaseService, IOrdemCompraService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.OrdemCompras.OrdemCompra> _repositoryOrdemCompra;
    private readonly IBaseRepository<DetalhesOrdemCompra> _repositoryDetalhesOrdemCompra;
    private readonly IBaseRepository<Entity.Fornecedores.Fornecedor> _repositoryFornecedor;
    private readonly IBaseRepository<Entity.Departamentos.Departamento> _repositoryDepartamento;
    private readonly IUnitOfWork _unitOfWork;
    
    public OrdemCompraService(
        IMapper mapper,
        IBaseRepository<Entity.OrdemCompras.OrdemCompra> repositoryOrdemCompra,
        IBaseRepository<DetalhesOrdemCompra> repositoryDetalhesOrdemCompra,
        IBaseRepository<Entity.Fornecedores.Fornecedor> repositoryFornecedor,
        IBaseRepository<Entity.Departamentos.Departamento> repositoryDepartamento,
        IUnitOfWork unitOfWork,
        ILogger<OrdemCompraService> logger) : base(logger)
    {
        _mapper = mapper;
        _repositoryOrdemCompra = repositoryOrdemCompra;
        _repositoryDetalhesOrdemCompra = repositoryDetalhesOrdemCompra;
        _repositoryFornecedor = repositoryFornecedor;
        _repositoryDepartamento = repositoryDepartamento;
        _unitOfWork = unitOfWork;
    }
}