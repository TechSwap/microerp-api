using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.UpdateUser;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.UpdateUser;

public class UpdateUserRequest : UpdateUserRequestDto, IRequest<ResponseDto<None>>
{
}
