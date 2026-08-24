using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Response.Product
{
    public record ProductResponse(Guid Id,string Name,string Description,int Quantity,Decimal Price,DateTime CreatedDate,bool IsDeleted,Guid CreatedById,int? MinimumQuantity,string? Category);
    
}
