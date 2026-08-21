using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRespository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IProductServices productServices { get; }
        Task SaveAsync();
    }
}
