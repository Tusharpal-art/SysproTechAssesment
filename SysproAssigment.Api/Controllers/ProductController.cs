using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysproAssigment.Application.Request.Product;

namespace SysproAssigment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [Authorize(Roles ="Admin")]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAysnc([FromBody] AddProductRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] UpdateProductRqquest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProductAsync([FromQuery] GetAllProductListRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet("GetProductQuantity")]
        public async Task<IActionResult> GetProductQuantityAsync([FromQuery] GetProductQuantityRequest request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

    }
}
