using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Implementation
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
