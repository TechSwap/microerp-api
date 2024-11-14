using AutoMapper;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Service.Abstract.Interfaces.Maquina;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Maquina;

public partial class MaquinaService: BaseService, IMaquinaService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;
    private readonly IBaseRepository<Entity.Maquinas.Maquina> _repository;
    public MaquinaService(ILogger<MaquinaService> logger
        , IBaseRepository<Entity.Maquinas.Maquina> repository
        , IConfiguration config
        , IMapper mapper) : base(logger)
    {
        _config = config;
        _mapper = mapper;
        _repository = repository;
    }
}