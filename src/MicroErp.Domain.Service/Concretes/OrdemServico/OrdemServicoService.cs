using AutoMapper;
using MicroErp.Domain.Entity.Clientes;
using MicroErp.Domain.Entity.OrdemServicos;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemServico;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemServico;

public partial class OrdemServicoService: BaseService, IOrdemServicoService
{
    
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.OrdemServicos.OrdemServico> _repositoryOrdemServico;
    private readonly IBaseRepository<DetalhesOrdemServico> _repositoryDetalhesOrdemServico;
    private readonly IBaseRepository<Entity.Fornecedores.Fornecedor> _repositoryFornecedor;
    private readonly IBaseRepository<Cliente> _repositoryCliente;
    private readonly IUnitOfWork _unitOfWork;
    
    
    public OrdemServicoService(
        IMapper mapper,
        IBaseRepository<Entity.OrdemServicos.OrdemServico> repositoryOrdemServico,
        IBaseRepository<DetalhesOrdemServico> repositoryDetalhesOrdemServico,
        IBaseRepository<Entity.Fornecedores.Fornecedor> repositoryFornecedor,
        IBaseRepository<Cliente> repositoryCliente,
        IUnitOfWork unitOfWork,
        ILogger<OrdemServicoService> logger) : base(logger)
    {
        _mapper = mapper;
        _repositoryOrdemServico = repositoryOrdemServico;
        _repositoryDetalhesOrdemServico = repositoryDetalhesOrdemServico;
        _repositoryFornecedor = repositoryFornecedor;
        _repositoryCliente = repositoryCliente;
        _unitOfWork = unitOfWork;
    }
}