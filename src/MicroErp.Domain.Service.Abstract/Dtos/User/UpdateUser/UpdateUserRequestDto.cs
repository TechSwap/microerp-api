using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.UpdateUser;

public class UpdateUserRequestDto : RequestDto
{
	public string Email { get; set; }
	public string Nome { get; set; }
	public string Celular { get; set; }
	public bool AtivoUsuario { get; set; }
	public bool Adm { get; set; }
}
