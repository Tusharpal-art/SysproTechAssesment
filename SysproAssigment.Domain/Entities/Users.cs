using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Domain.Entities
{
    public class Users : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Products>? Products { get; set; }
        public virtual ICollection<Sales>? Sales { get; set; }
    }
}
