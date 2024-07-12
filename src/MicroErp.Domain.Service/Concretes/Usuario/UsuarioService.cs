using AutoMapper;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Service.Abstract.Interfaces.Usuarios;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Usuario;

public partial class UsuarioService: BaseService, IUsuarioService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<UserEntity> _repository;
    private readonly IBaseRepository<Entity.Departamentos.Departamento> _repositoryDepartamento;
    private readonly UserManager<User> _userManager;        
    
    public UsuarioService(IConfiguration config, 
        IMapper mapper,
        IBaseRepository<UserEntity> repository, 
        IBaseRepository<Entity.Departamentos.Departamento> repositoryDepartamento,
        UserManager<User> userManager,  
        ILogger<UsuarioService> logger) : base(logger)
    {
        _config = config;
        _mapper = mapper;
        _repository = repository;
        _repositoryDepartamento = repositoryDepartamento;
        _userManager = userManager;
    }
}