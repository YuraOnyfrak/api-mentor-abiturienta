using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class SpecializationRepository : GenericRepository<Specialization>, ISpecializationRepository
  {
    public SpecializationRepository(IStorageContext context) : base(context)
    {
    }

    public IQueryable<Specialization> GetBySpeciality(int specialityId)
    {
      return from s in Context.Specializations
            // join sf in Context.SpecialityByFaculty on s.SpecialityByFacultyId equals sf.Id
             where s.SpecialityByFacultyId == specialityId
             select s;
    }
  }
}
