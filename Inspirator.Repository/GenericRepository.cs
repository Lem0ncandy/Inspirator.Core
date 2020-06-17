using Inspirator.IRepository;
using Inspirator.Model.Context;
using Inspirator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Inspirator.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MainContext _context;

        public GenericRepository(MainContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> RemoveAsync(TEntity entity)
        {
            entity = (await FindAsync(entity.Id)) ?? throw new NullReferenceException();
            entity.IsRemove = true;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> InsertAsync(List<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(x => x.IsRemove == false).Where(expression);
        }

        public async Task<TEntity> FindAsync(TEntity Entity)
        {
            return await this.FindAsync(Entity.Id);
        }

        public async Task<TEntity> FindAsync(Guid Id)
        {
            return await _context.Set<TEntity>().Where(x => x.Id == Id && x.IsRemove == false).SingleOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            entity = await this.FindAsync(entity) ?? throw new NullReferenceException();
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }


    }
}
