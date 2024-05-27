using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.Token.UserLoginResponse
{
    public class UserLoginRequestDto : RequestDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
