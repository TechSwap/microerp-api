using MediatR;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.ConfirmEmail;
using MicroErp.Infra.CrossCuting;

namespace MicroErp.Application.UserCases.User.ConfirmEmail;

public class ConfirmEmailRequest : ConfirmEmailRequestDto, IRequest<ResponseDto<None>>
{
}
