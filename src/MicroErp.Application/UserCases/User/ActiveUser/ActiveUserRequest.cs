using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ActiveUser;

public class ActiveUserRequest : FindOneUserRequestDto, IRequest<ResponseDto<None>>
{
    
}