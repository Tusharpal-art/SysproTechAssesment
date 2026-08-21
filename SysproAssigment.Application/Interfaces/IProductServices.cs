using SysproAssigment.Application.Request.Product;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Interfaces
{
    public interface IProductServices
    {
        public Task<AllRecord<Products>> GetAllProductsAsync( GetAllProductListRequest request);
        public Task<int> GetProductQuqntity(GetProductQuantityRequest request);
    }
}
