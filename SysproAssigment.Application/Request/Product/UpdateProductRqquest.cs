using MediatR;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Request.Product
{
    public class UpdateProductRqquest: IRequest<Result<ProductResponse>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string? Category { get; set; } = String.Empty;
        public int? MinimumQuantity { get; set; } = 0;
        public decimal Price { get; set; }
    }
}
