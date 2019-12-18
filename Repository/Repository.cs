using CozaStorev2.Models;
using DataContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    class Repository
    {
        public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            protected CozaStoreContext CozaStoreContext { get; set; }
            public RepositoryBase(CozaStoreContext repositoryContext)
            {
                CozaStoreContext = repositoryContext;
            }

            public IQueryable<T> FindAll()
            {
                return CozaStoreContext.Set<T>().AsNoTracking();
            }

            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
            {
                return CozaStoreContext.Set<T>().Where(expression).AsNoTracking();
            }
           
            public void Create(T entity)
            {
                CozaStoreContext.Set<T>().Add(entity);
            }

            public void Update(T entity)
            {
                CozaStoreContext.Set<T>().Update(entity);
            }

            public void Delete(T entity)
            {
                CozaStoreContext.Set<T>().Remove(entity);
            }
          
        }
    }

}

