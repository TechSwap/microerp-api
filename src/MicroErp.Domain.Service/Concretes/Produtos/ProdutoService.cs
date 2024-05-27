using AutoMapper;
using MicroErp.Domain.Entity.Clientes;
using MicroErp.Domain.Entity.Produtos;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Produto;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Produtos;

public partial class ProdutoService: BaseService, IProdutoService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Produto> _repositoryProduto;
    private readonly IBaseRepository<Cliente> _repositoryCliente;
    private readonly IBaseRepository<Entity.Fornecedores.Fornecedor> _repositoryFornecedor;
    private readonly IUnitOfWork _unitOfWork;
    
    public ProdutoService(
        IMapper mapper,
        IBaseRepository<Produto> repositoryProduto,
        IBaseRepository<Cliente> repositoryCliente,
        IBaseRepository<Entity.Fornecedores.Fornecedor> repositoryFornecedor,
        IUnitOfWork unitOfWork,
        ILogger<ProdutoService> logger) : base(logger)
    {
        _mapper = mapper;
        _repositoryProduto = repositoryProduto;
        _repositoryCliente = repositoryCliente;
        _repositoryFornecedor = repositoryFornecedor;
        _unitOfWork = unitOfWork;
    }
}