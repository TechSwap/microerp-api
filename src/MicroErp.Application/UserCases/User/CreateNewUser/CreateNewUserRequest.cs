using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.CreateNewUser;

public class CreateNewUserRequest : AddNewUserRequestDto, IRequest<ResponseDto<None>>
{
}