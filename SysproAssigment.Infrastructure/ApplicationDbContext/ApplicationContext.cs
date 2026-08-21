using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SysproAssigment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Infrastructure.ApplicationDbContext
{
    public class ApplicationContext(DbContextOptions options) :IdentityDbContext<Users,IdentityRole<Guid>,Guid>(options)
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Products>(entity => {

                entity.HasOne(x => x.CreatedBy)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            
            });

            builder.Entity<Sales>(entity => {

                entity.HasOne(x => x.OrderBy)
                .WithMany(x => x.Sales).
                HasForeignKey(x => x.OrderbyId)
                .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(x => x.Product)
                .WithMany(x=>x.Sales)
                .HasForeignKey(x=>x.ProductId)
                .OnDelete(DeleteBehavior.SetNull);

            });

            Guid userId = Guid.Parse("F3D48C5C-025E-48BA-BB58-35616C955716");
            Guid UserRoleId = Guid.Parse("ED7EC390-1CEB-4F5F-8B67-D640CCAF179D");
            Guid AdminRoleId = Guid.Parse("ADC7C6CF-943A-48B2-8097-6957BD38CA55");

            PasswordHasher<Users> hasher = new();

            Users adminUser = new()
            {
                Id = userId,
                Name = "Admin",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com".ToUpper(),
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "8839180582",
                PhoneNumberConfirmed = true,
                SecurityStamp = "D0149F2B-64AC-4D20-A6CB-C0EC6C9391EE".ToString(),
                PasswordHash = "AQAAAAIAAYagAAAAEIIpsj0Vs2zth/t5k7Zi2fz0f/Kqvgl7+fmGOx9/277S7S/ONNSkhReQIxu9cPUHxw==",
                ConcurrencyStamp = "b7dff1a2-fb8f-4bd3-90bd-b2d1ea1e4fd2"
            };

           // adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            List<IdentityRole<Guid>> role = [
                new IdentityRole<Guid>()
                {
                Id = AdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp  = "adc7c6cf-943a-48b2-8097-6957bd38ca55"
                },
                new IdentityRole<Guid>()
                {
                Id = UserRoleId,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "ed7ec390-1ceb-4f5f-8b67-d640ccaf179d"
                }
            ];

            IdentityUserRole<Guid> adminUserRole = new()
            {
                RoleId = AdminRoleId,
                UserId = userId
            };

            builder.Entity<Users>()
                .HasData(adminUser);

            builder.Entity<IdentityRole<Guid>>()
            .HasData(role);

            builder.Entity<IdentityUserRole<Guid>>()
            .HasData(adminUserRole);
        }
    }
    
}
