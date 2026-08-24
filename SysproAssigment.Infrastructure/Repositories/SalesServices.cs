using Microsoft.EntityFrameworkCore;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Application.Request.Sales;
using SysproAssigment.Application.Response.Sales;
using SysproAssigment.Domain.Entities;
using SysproAssigment.Infrastructure.ApplicationDbContext;
using SysproAssigment.Shared.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Infrastructure.Repositories
{
    public class SalesServices(ApplicationContext context ) : ISalesServices
    {
       

        public async Task<AllRecord<Sales>> GetAllSalesList(GetAllOderRequest request)
        {
            IQueryable<Sales> SalesList = context.Sales;
           




            // apply searching
            if (request.Search != null)
            {
                request.Search = request.Search!.ToLower();
                SalesList = SalesList.Where(a => a.Product.Name.ToLower().Contains(request.Search!) || a.OrderDate.ToString().ToLower().Contains(request.Search!)
                            || a.ProductCount.ToString().ToLower().Contains(request.Search!) || a.TotalPrice.ToString().ToLower().Contains(request.Search!)
                          ||  a.UnitPrice.ToString().ToLower().Contains(request.Search!) );
            }

            // apply sorting
            if (!string.IsNullOrWhiteSpace(request.SortBy))
            {
                if (request.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    SalesList = request.IsAscending ? SalesList.OrderBy(x => x.Id) : SalesList.OrderByDescending(x => x.Id);
                }
                else if (request.SortBy.Equals("TotalPrice", StringComparison.OrdinalIgnoreCase))
                {
                    SalesList = request.IsAscending ? SalesList.OrderBy(x => x.TotalPrice) : SalesList.OrderByDescending(x => x.TotalPrice);
                }
                else if (request.SortBy.Equals("UnitPrice", StringComparison.OrdinalIgnoreCase))
                {
                    SalesList = request.IsAscending ? SalesList.OrderBy(x => x.UnitPrice) : SalesList.OrderByDescending(x => x.UnitPrice);
                }
                else if (request.SortBy.Equals("ProductName", StringComparison.OrdinalIgnoreCase))
                {
                    SalesList = request.IsAscending ? SalesList.OrderBy(x => x.Product.Name) : SalesList.OrderByDescending(x => x.Product.Name);
                }
                else if (request.SortBy.Equals("OrderDate", StringComparison.OrdinalIgnoreCase))
                {
                    SalesList = request.IsAscending ? SalesList.OrderBy(x => x.OrderDate) : SalesList.OrderByDescending(x => x.OrderDate);
                }
            }

            int totalRecord = SalesList.Count();
            List<Sales> productList = await SalesList.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return new AllRecord<Sales>(productList, totalRecord);
        }
    }
}
