using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversityInfo.DAL.Implementation
{
  public class SpecialityRepository : GenericRepository<Speciality>, ISpecialityRepository
  {
    public SpecialityRepository(IStorageContext context) : base(context)
    {
    }

    public IQueryable<Speciality> GetByFaculty(int idFaculty)
    {
            //return from s in Context.Specialties
            //       join sf in Context.SpecialityByFaculty on s.Id equals sf.SpecialityId
            //       where sf.FacultyId == idFaculty
            //       select s;
        return  Context.Specialties.Include(s => s.SpecialityByFaculty)
               .Where(s => s.SpecialityByFaculty.FacultyId == idFaculty)
               .Select(s => s);

    }
  }
}
