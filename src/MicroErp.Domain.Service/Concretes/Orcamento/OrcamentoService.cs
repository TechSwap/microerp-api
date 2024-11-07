using AutoMapper;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Orcamento;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Orcamento;

public partial class OrcamentoService: BaseService, IOrcamentoService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.Orcamentos.Orcamento> _repository;   
    private readonly IBaseRepository<Entity.Orcamentos.DetalheOrcamento> _repositoryDetalheOrcamento;
    private readonly IUnitOfWork _unitOfWork;
    
    public OrcamentoService(
        IMapper mapper,
        IBaseRepository<Entity.Orcamentos.Orcamento> repository,
        IBaseRepository<Entity.Orcamentos.DetalheOrcamento> repositoryDetalheOrcamento,
        IUnitOfWork unitOfWork,
        ILogger<OrcamentoService> logger) : base(logger)
    {
        _mapper = mapper;
        _repository = repository;
        _repositoryDetalheOrcamento = repositoryDetalheOrcamento;
        _unitOfWork = unitOfWork;
    }
}