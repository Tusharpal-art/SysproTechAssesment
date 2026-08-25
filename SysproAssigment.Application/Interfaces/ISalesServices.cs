using SysproAssigment.Application.Request.Sales;
using SysproAssigment.Application.Response.Sales;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Interfaces
{
    public interface ISalesServices
    {
        Task<AllRecord<Sales>> GetAllSalesList(GetAllOderRequest request,Guid? UserId);
        
    }
}
