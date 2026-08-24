using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SysproAssigment.Application.Response.Auth;
using SysproAssigment.Shared.Response;

namespace SysproAssigment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] Application.Request.Auth.RegisterRequest request)
        {
            Result<RegisterRespone> result = await mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] Application.Request.Auth.LoginRequest request)
        {
           Result<LoginResponse> result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
