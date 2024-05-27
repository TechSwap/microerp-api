using MicroErp.Domain.Entity.Bases;

namespace MicroErp.Domain.Entity.Users;

public class UserEntity : BaseEntity
{
	public string Nome { get; set; }
	public string SobreNome { get; set; }
	public string Avatar { get; set; }
}
