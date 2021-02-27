using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.DAL.Domain.Common;

namespace MentorAbiturienta.DAL
{
  public class GenericRepository<TEntity> : IGenericRepository<TEntity>
          where TEntity : Identifiable
  {
        private  IStorageContext _context;

        protected DbContext storageContext;

        /// <summary>
        /// Sets the Entity Framework storage context that represents the physical storage to work with.
        /// </summary>
        /// <param name="storageContext">The Entity Framework storage context to set.</param>
        public void SetStorageContext(IStorageContext storageContext)
        {
          this.storageContext = storageContext as DbContext; // TODO ??
          _context = storageContext;
        }

        public GenericRepository(IStorageContext context)
    {
      _context = context;
    }

        public MentorAbiturientaContext Context
        {
          get { return _context as MentorAbiturientaContext; }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
          return await Context.Set<TEntity>().ToListAsync();
        }

        public virtual IQueryable<TEntity> Get()
        {
          return  Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(int id)
        {
          return Context.Set<TEntity>();//.Where(s=>s.);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
          await Context.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task<TEntity> DeleteAsync(ulong id)
        {
          var entity = await Context.Set<TEntity>().FindAsync(id);
          if (entity != null)
          {
            Context.Set<TEntity>().Remove(entity);
          }

          return entity;
        }

        public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
          throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
          throw new NotImplementedException();
        }

        public virtual Task<TEntity> GetAsync(Guid id)
    {
      throw new NotImplementedException();
    }

        public virtual Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
      throw new NotImplementedException();
    }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
    }
}
