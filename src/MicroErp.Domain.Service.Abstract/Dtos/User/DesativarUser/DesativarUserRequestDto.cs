using MicroErp.Domain.Service.Abstract.Dtos.Bases.Requests;

namespace MicroErp.Domain.Service.Abstract.Dtos.User.DesativarUser;

public class DesativarUserRequestDto : RequestDto
{
    public string IdUsuario { get; set; }
}
