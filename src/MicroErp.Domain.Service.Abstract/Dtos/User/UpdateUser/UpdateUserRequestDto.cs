using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.UpdateUser;

public class UpdateUserRequestDto : RequestDto
{
	public string UserId { get; set; }
	public string Nome { get; set; }
	public string Email { get; set; }
	public string IdDepartamento { get; set; }
	public bool Ativo { get; set; }
	public string? Role { get; set; }
}
