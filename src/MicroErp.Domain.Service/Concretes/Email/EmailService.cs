
using MicroErp.Domain.Service.Abstract.Interfaces.Email;
using MicroErp.Domain.Service.Concretes.Bases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroErp.Domain.Service.Concretes.Email;

public partial class EmailService : BaseService, IEmailService
{
    private readonly IConfiguration _config;
    public EmailService(ILogger<EmailService> logger, IConfiguration config) : base(logger)
    {
        _config = config;
    }    
}
