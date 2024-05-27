using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;

public class FindOneUserRequestDto : RequestDto
{
	public string Id { get; set; }
}