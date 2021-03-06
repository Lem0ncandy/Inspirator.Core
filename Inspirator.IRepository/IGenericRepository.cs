﻿using Inspirator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inspirator.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> FindAsync(Guid Id);
        Task<TEntity> FindAsync(TEntity Entity);
        IQueryable<TEntity> Find();
        IQueryable<TEntity> Find(int page, int size);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression, int page, int size);
        Task InsertAsync(TEntity entity);
        Task InsertAsync(List<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        //IQueryable<TEntity> InnerJoin(TEntity inner, TEntity outer);
    }
}
