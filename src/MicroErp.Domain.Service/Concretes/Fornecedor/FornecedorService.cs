using AutoMapper;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Entity.Fornecedores;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Forncedor;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Fornecedor;

public partial class FornecedorService : BaseService, IFornecedorService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.Fornecedores.Fornecedor> _repositoryFornecedor;
    private readonly IBaseRepository<Endereco> _repositoryEndereco;
    private readonly IUnitOfWork _unitOfWork;

    public FornecedorService(
        IMapper mapper,
        IBaseRepository<Entity.Fornecedores.Fornecedor> repositoryFornecedor,
        IBaseRepository<Endereco> repositoryEndereco,
        IUnitOfWork unitOfWork,
        ILogger<FornecedorService> logger) : base(logger)
    {
        _repositoryFornecedor = repositoryFornecedor;
        _mapper = mapper;
        _repositoryEndereco = repositoryEndereco;
        _unitOfWork = unitOfWork;
    }
}
