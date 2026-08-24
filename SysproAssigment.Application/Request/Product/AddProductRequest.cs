using MediatR;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Request.Product
{
    public class AddProductRequest:IRequest<Result<ProductResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? MinimumQuantity { get; set; } = 0;
        public string? Category { get; set; } = String.Empty;
    }
}
