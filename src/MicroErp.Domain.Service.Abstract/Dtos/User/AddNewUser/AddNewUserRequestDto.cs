using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;

public class AddNewUserRequestDto : RequestDto
{
	public string Nome { get; set; }
	public string IdDepartamento { get; set; }
	public string Email { get; set; }
    public string Senha { get; set; }
    public string ConfirmarSenha { get; set; }
    public string Rule { get; set; }
}