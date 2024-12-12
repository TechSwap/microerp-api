using AutoMapper;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Service.Abstract.Interfaces.Operacao;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Operacao;

public partial class OperacaoService: BaseService, IOperacaoService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.Operacoes.Operacao> _repository;  
    private readonly IBaseRepository<Entity.Departamentos.Departamento> _repositoryDepartamento;  
    
    public OperacaoService(ILogger<OperacaoService> logger
        , IBaseRepository<Entity.Operacoes.Operacao> repository
        , IBaseRepository<Entity.Departamentos.Departamento> repositoryDepartamento
        , IMapper mapper) : base(logger)
    {
        _mapper = mapper;
        _repository = repository;
        _repositoryDepartamento = repositoryDepartamento;
    }
}