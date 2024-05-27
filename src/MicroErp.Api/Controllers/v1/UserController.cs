using MediatR;
using MicroErp.Api.Controllers.Bases;
using MicroErp.Application.UserCases.User.ConfirmEmail;
using MicroErp.Application.UserCases.User.CreateNewUser;
using MicroErp.Application.UserCases.User.FindOneUser;
using MicroErp.Application.UserCases.User.ForgotPassword;
using MicroErp.Application.UserCases.User.ResetPassword;
using MicroErp.Application.UserCases.User.UpdateUser;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Domain.Service.Abstract.Dtos.User.AddNewUser;
using MicroErp.Domain.Service.Abstract.Dtos.User.FindOneUser;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.v1;

//[Authorize("Bearer")]
public class UserController : ApiControllerBase
{
	private readonly IMediator _mediator;

	public UserController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	[ProducesResponseType(typeof(ResponseDto<FindOneUserResponseDto>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get([FromQuery] string id)
	{
		var response = await _mediator.Send(new FindOneUserRequest { Id = id });
		return CreateResult(response);
	}

	[HttpPost]
	[ProducesResponseType(typeof(ResponseDto<AddNewUserRequestDto>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> PostUser([FromBody] CreateNewUserRequest request)
	{
		var response = await _mediator.Send(request);
		return CreateResult(response);
	}

	[HttpPut]
	[ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> PutUser([FromBody] UpdateUserRequest request)
	{
		var response = await _mediator.Send(request);
		return CreateResult(response);
	}

	[HttpGet("forgot-password")]
	[ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetForgotPassword([FromQuery] ForgotPasswordRequest request)
	{
		var response = await _mediator.Send(request);
		return CreateResult(response);
	}

	[HttpGet("confirm-email")]
	[ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetConfirmEmail([FromQuery] ConfirmEmailRequest request)
	{
		var response = await _mediator.Send(request);
		return CreateResult(response);
	}


	[HttpPost("reset-password")]
	[ProducesResponseType(typeof(ResponseDto<None>), StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> PostResetPassword([FromBody] ResetPasswordRequest request)
	{
		var response = await _mediator.Send(request);
		return CreateResult(response);
	}
}