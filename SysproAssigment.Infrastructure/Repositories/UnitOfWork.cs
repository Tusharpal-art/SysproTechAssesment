using SysproAssigment.Application.Interfaces;
using SysproAssigment.Infrastructure.ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysproAssigment.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationContext context, IProductServices product,ISalesServices salesServices) : IUnitOfWork
    {
        private readonly ApplicationContext dbContext = context;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        public IProductServices productServices => product;

        public ISalesServices SalesServices => salesServices;

        public IGenericRespository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IGenericRespository<TEntity>)_repositories[typeof(TEntity)];
            }

            var repository = new GenericRepository<TEntity>(dbContext);

            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
