using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;

public class AddNewUserRequestDto : RequestDto
{
	public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }    
}