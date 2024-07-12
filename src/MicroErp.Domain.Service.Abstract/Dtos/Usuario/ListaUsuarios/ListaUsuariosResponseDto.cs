namespace MicroErp.Domain.Service.Abstract.Dtos.Usuario.ListaUsuarios;

public class ListaUsuariosResponseDto
{
    public string UserId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public bool Ativo { get; set; }
    public string IdDepartamento { get; set; }
    public string Departamento { get; set; }
}