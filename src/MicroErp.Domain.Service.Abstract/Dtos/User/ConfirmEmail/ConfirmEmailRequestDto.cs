using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.ConfirmEmail;

public class ConfirmEmailRequestDto : RequestDto
{
	public string UserId { get; set; }
	public string Code { get; set; }
}
