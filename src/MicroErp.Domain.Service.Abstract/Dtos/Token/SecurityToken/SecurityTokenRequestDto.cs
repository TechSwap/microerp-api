using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Token.SecurityToken;

public class SecurityTokenRequestDto : RequestDto
{    
    public string RefreshToken { get; set; }
}
