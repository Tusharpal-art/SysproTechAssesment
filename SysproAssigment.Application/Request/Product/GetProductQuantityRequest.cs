using MediatR;
using SysproAssigment.Application.Response.Product;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Request.Product
{
    public class GetProductQuantityRequest:IRequest<Result<ProductCountResponse>>
    {
        public Guid Id { get; set;  }
    }
}
