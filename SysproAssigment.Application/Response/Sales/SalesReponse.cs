using SysproAssigment.Application.Response.Product;
using SysproAssigment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Response.Sales
{
    public class SalesReponse
    {
        public int Id { get; set; }
        public Guid? OrderbyId { get; set; }
        public Decimal? TotalPrice { get; set; } = 0;
        public decimal UnitPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid? ProductId { get; set; }
        public virtual ProductResponse? Product { get; set; }
        public int ProductCount { get; set; } = 0;
    }
}
