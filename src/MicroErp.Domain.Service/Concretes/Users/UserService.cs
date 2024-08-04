using AutoMapper;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Service.Abstract.Interfaces.Email;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService : BaseService, IUserService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<UserEntity> _repository;
    private readonly IBaseRepository<Entity.Departamentos.Departamento> _repositoryDepartamento;
    private readonly UserManager<User> _userManager;        
    private readonly IEmailService _emailService;
    private readonly IAuthenticatedUserService _user;
    public UserService(ILogger<UserService> logger,
        IMapper mapper,
        IBaseRepository<UserEntity> repository,
        UserManager<User> userManager,        
        IConfiguration config,
        IAuthenticatedUserService user,
        IBaseRepository<Entity.Departamentos.Departamento> repositoryDepartamento,
        IEmailService emailService) : base(logger)
    {
        _mapper = mapper;
        _repository = repository;
        _repositoryDepartamento = repositoryDepartamento;
        _userManager = userManager;
        _config = config;
        _emailService = emailService;
        _user = user;
    }	
}