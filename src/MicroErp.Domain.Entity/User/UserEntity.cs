using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Users;

public class UserEntity : BaseEntity
{
	public string Nome { get; set; }
	public string SobreNome { get; set; }
	public string Avatar { get; set; }
	public string Email { get; set; }
	public bool AtivoUsuario { get; set; }
	public string IdDepartamento { get; set; }
	public DateTime? DataAtualizacao { get; set; }
}
