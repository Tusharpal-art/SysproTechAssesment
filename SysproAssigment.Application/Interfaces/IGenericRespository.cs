using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Interfaces
{
    public interface IGenericRespository<T> where T :class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
