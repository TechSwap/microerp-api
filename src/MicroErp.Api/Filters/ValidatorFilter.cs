using MicroErp.Api.Extensions;
using MicroErp.Domain.Service.Abstract.Dtos.Bases.Responses;
using MicroErp.Infra.CrossCuting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MicroErp.Api.Filters;

public class ValidatorFilter : IAsyncActionFilter
{

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            context.Result = new BadRequestObjectResult(ResponseDto<None>.Fail(context.ModelState.GetErrors()));
            return;
        }

        await next().ConfigureAwait(false);
    }
}