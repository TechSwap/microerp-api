using AutoMapper;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.Departamentos.AddDepartamento;
using MicroErp.Domain.Service.Abstract.Interfaces.Departamento;
using MicroErp.Domain.Service.Concretes.Bases;
using MicroErp.Infra.CrossCuting;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Departamento;

public partial class DepartamentoService: BaseService, IDepartamentoService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Entity.Departamentos.Departamento> _repository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DepartamentoService(
        IMapper mapper,
        IBaseRepository<Entity.Departamentos.Departamento> repository,
        IUnitOfWork unitOfWork,
        ILogger<DepartamentoService> logger) : base(logger)
    {
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
}