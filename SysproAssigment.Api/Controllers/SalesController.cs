using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysproAssigment.Application.Request.Product;
using SysproAssigment.Application.Request.Sales;

namespace SysproAssigment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController(IMediator mediator) : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrderAysnc([FromBody] AddOrderRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [Authorize(Roles = "User")]
        [HttpGet("GetAllOrderList")]
        public async Task<IActionResult> GetAllOrderList([FromQuery] GetAllOderRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}
