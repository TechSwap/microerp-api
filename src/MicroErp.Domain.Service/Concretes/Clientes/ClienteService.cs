using AutoMapper;
using MicroErp.Domain.Entity.Clientes;
using MicroErp.Domain.Entity.Enderecos;
using MicroErp.Domain.Repository.Orm.Abstract.Repositories;
using MicroErp.Domain.Repository.Orm.Abstract.UnitOfWork;
using MicroErp.Domain.Service.Abstract.Interfaces.Cliente;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Clientes;

public partial class ClienteService: BaseService, IClienteService
{
    private readonly IMapper _mapper;
    private readonly IBaseRepository<Cliente> _repositoryCliente;
    private readonly IBaseRepository<Endereco> _repositoryEndereco;
    private readonly IUnitOfWork _unitOfWork;

    public ClienteService(
        IMapper mapper,
        IBaseRepository<Cliente> repositoryCliente,
        IBaseRepository<Endereco> repositoryEndereco,
        IUnitOfWork unitOfWork,
        ILogger<ClienteService> logger) : base(logger)
    {
        _mapper = mapper;
        _repositoryCliente = repositoryCliente;
        _repositoryEndereco = repositoryEndereco;
        _unitOfWork = unitOfWork;
    }
}