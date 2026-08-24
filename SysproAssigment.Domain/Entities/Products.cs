using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Domain.Entities
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 0;
        public decimal Price { get; set; }
        public int? MinimumQuantity { get; set; } = 0;
        public string? Category { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; }  = DateTime.Now;
        public DateTime DeletedDate { get; set; } 
        public bool IsDeleted { get; set; } = false;
        public Guid? CreatedById { get; set; }
        public virtual Users? CreatedBy { get; set; }
        public virtual ICollection<Sales>? Sales { get; set; }

    }
}
