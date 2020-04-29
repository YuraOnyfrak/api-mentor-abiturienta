using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Abstraction
{
    public interface IUniversityRepository : IGenericRepository<University>
    {
        Task<IEnumerable<University>> GetByCityAsync(int cityId);
    }
}
