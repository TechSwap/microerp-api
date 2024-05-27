using System.Web;
using AutoMapper;
using MediatR;
using MicroErp.Application.Util;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Domain.Service.Abstract.Interfaces.Users;

namespace MicroErp.Application.UserCases.User.FindOneUser;

public class FindOneUserHandler : IRequestHandler<FindOneUserRequest, ResponseDto<FindOneUserResponseDto>>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public FindOneUserHandler(IMapper mapper, IUserService userService)
    {

        _mapper = mapper;
        _userService = userService;
    }

    public async Task<ResponseDto<FindOneUserResponseDto>> Handle(FindOneUserRequest request, CancellationToken cancellationToken)
    {
        FindOneUserRequest request0 = new FindOneUserRequest();
        request0.Id = CriptografiaHelper.DecryptQueryString(HttpUtility.UrlDecode(request.Id));

        return await _userService.FindOneUserAsync(request0, cancellationToken);
    }

}