using AutoMapper;
using MicroErp.Domain.Entity.Clientes;
using MicroErp.Domain.Entity.OrdemProducao;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.OrdemProducao;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.OrdemProducao;

public partial  class OrdemProducaoService: BaseService, IOrdemProducaoService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.OrdemProducao.OrdemProducao> _repositoryOrdemProducao;
    private readonly IBaseRepository<DetalhesOrdemProducao> _repositoryDetalhesOrdemProducao;
    private readonly IBaseRepository<Cliente> _repositoryCliente;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _config;
    
    public OrdemProducaoService(ILogger<OrdemProducaoService> logger
        , IMapper mapper
        , IBaseRepository<Entity.OrdemProducao.OrdemProducao> repositoryOrdemProducao
        , IBaseRepository<DetalhesOrdemProducao> repositoryDetalhesOrdemProducao
        , IBaseRepository<Cliente> repositoryCliente
        , IUnitOfWork unitOfWork
        , IConfiguration config) : base(logger)
    {
        _mapper = mapper;
        _repositoryOrdemProducao = repositoryOrdemProducao;
        _repositoryDetalhesOrdemProducao = repositoryDetalhesOrdemProducao;
        _repositoryCliente = repositoryCliente;
        _unitOfWork = unitOfWork;
        _config = config;
    }
}