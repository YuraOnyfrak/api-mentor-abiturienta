using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MentorAbiturienta.DAL.Implementation
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
