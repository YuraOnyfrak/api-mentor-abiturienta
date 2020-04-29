using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL
{
  public interface IGenericRepository<TEntity>
          where TEntity : Identifiable
  {
        Task<IEnumerable<TEntity>> GetAllAsync();
        IQueryable<TEntity> Get();
        Task<TEntity> DeleteAsync(ulong id);
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(Guid id);
        IQueryable<TEntity> Get(int id);
        void Update(TEntity entity);
  }
}
