using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Domain.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public Guid? OrderbyId { get; set; }
        public Decimal? TotalPrice { get; set; } = 0;
        public decimal UnitPrice { get; set; }
        public virtual Users? OrderBy {  get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Guid? ProductId { get; set; }
        public virtual Products? Product { get; set; }
        public int ProductCount { get; set; } = 0;

    }
}
