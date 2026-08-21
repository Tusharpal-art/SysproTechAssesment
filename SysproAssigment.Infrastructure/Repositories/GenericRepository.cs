using Microsoft.EntityFrameworkCore;
using SysproAssigment.Application.Interfaces;
using SysproAssigment.Infrastructure.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Infrastructure.Repositories
{
    public class GenericRepository<T>(ApplicationContext dbContext) : IGenericRespository<T> where T : class
    {
        public async Task<T> CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;

        }
        public virtual Task<List<T>> GetAllAsync()
        {
            return dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public Task<T> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            return Task.FromResult(entity);
        }
    }
}
