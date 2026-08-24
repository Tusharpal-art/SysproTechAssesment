using MediatR;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Request.Sales
{
    public class AddOrderRequest:IRequest<Result<bool>>
    {
        public Guid ProductId { get; set; }
        public int ProductQuantity { get; set; }
    }
}
