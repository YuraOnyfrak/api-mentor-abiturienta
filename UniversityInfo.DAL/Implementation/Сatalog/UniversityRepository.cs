using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class UniversityRepository : GenericRepository<University>, IUniversityRepository
  {
        public UniversityRepository(IStorageContext context) : base(context)
        {
        }

        public async Task<IEnumerable<University>> GetByCityAsync(int cityId)
        {
            return await this.Context.Universities
                .Where(s => s.CityId == cityId)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    }
}
