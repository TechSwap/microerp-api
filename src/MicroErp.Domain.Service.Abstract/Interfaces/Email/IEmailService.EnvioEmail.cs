using MicroErp.Domain.Service.Abstract.Dtos.Email;

namespace MicroErp.Domain.Service.Abstract.Interfaces.Email;

public partial interface IEmailService
{
    void EnvioEmailAsync(EmailRequestDto request);
}
