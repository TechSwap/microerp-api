using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;

namespace MicroErp.Application.UserCases.User.FindOneUser;

public class FindOneUserRequest : FindOneUserRequestDto, IRequest<ResponseDto<FindOneUserResponseDto>>
{

}