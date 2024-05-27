using Microsoft.AspNetCore.Mvc;

namespace MicroErp.Api.Controllers.Bases;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ApiResultController
{
}