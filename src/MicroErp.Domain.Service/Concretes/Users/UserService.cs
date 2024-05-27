using AutoMapper;
using MicroErp.Domain.Entity.Users;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Service.Abstract.Interfaces.Email;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Users;

public partial class UserService : BaseService, IUserService
{
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;
    private readonly IBaseRepository<UserEntity> _repository;
    private readonly UserManager<User> _userManager;        
    private readonly IEmailService _emailService;
    public UserService(ILogger<UserService> logger,
        IMapper mapper,
        IBaseRepository<UserEntity> repository,
        UserManager<User> userManager,        
        IConfiguration config,
        IEmailService emailService) : base(logger)
    {
        _mapper = mapper;
        _repository = repository;
        _userManager = userManager;
        _config = config;
        _emailService = emailService;
    }	
}