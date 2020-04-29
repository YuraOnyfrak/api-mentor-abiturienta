using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Abstraction
{
  public interface ISpecializationRepository : IGenericRepository<Specialization>
  {
    IQueryable<Specialization> GetBySpeciality(int specialityId);
  }
}
