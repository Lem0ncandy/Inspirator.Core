using Inspirator.Model.Entities;
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
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        Task<int> InsertAsync(TEntity entity);
        Task<int> InsertAsync(List<TEntity> entities);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> RemoveAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
    }
}
