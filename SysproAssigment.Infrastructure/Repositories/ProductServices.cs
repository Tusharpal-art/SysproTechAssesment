using Microsoft.EntityFrameworkCore;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Product;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Infrastructure.ApplicationDbContext;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Infrastructure.Repositories
{
    public class ProductServices(ApplicationContext context) : IProductServices
    {
        public async Task<AllRecord<Products>> GetAllProductsAsync(GetAllProductListRequest request)
        {
            IQueryable<Products> products = context.Products;
            if (request.IsDeleted == true)
            {
                products = products.Where(s => s.IsDeleted == false);
            }

           
          

            // apply searching
            if (request.Search != null)
            {
                request.Search = request.Search!.ToLower();
                products = products.Where(a => a.Name.ToLower().Contains(request.Search!) || a.Description.ToLower().Contains(request.Search!)
                            || a.Price.ToString().ToLower().Contains(request.Search!) || a.Quantity.ToString().ToLower().Contains(request.Search!)
                           );
            }

            // apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                if (request.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    products = request.IsAscending ? products.OrderBy(x => x.Name) : products.OrderByDescending(x => x.Name);
                }
                else if (request.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                {
                    products = request.IsAscending ? products.OrderBy(x => x.Price) : products.OrderByDescending(x => x.Price);
                }
                else if (request.SortBy.Equals("Quantity", StringComparison.OrdinalIgnoreCase))
                {
                    products = request.IsAscending ? products.OrderBy(x => x.Quantity) : products.OrderByDescending(x => x.Quantity);
                }
                else if (request.SortBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
                {
                    products = request.IsAscending ? products.OrderBy(x => x.Description) : products.OrderByDescending(x => x.Description);
                }
            }

            int totalRecord = products.Count();
            List<Products> productList = await products.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return new AllRecord<Products>(productList,totalRecord);
        }

        public async Task<int> GetProductQuqntity(GetProductQuantityRequest request)
        {
            var value = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            return value!.Quantity;
        }
    }
}
