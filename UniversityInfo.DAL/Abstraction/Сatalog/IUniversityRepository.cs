using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Abstraction
{
    public interface IUniversityRepository : IGenericRepository<University>
    {
        Task<IEnumerable<University>> GetByCityAsync(int cityId);
    }
}
