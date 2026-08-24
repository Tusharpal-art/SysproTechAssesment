using MediatR;
using SysproAssigment.Application.Response.Sales;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Request.Sales
{
    public class GetAllOderRequest:IRequest<Result<AllRecord<SalesReponse>>>
    {
        public bool IsDeleted { get; set; } = true;
        public string? Search { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public string? SortBy { get; set; } = null;
        public bool IsAscending { get; set; } = true;
    }
}
