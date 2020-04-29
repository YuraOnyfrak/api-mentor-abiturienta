using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Abstraction
{
  public interface ISpecialityRepository : IGenericRepository<Speciality>
  {
    IQueryable<Speciality> GetByFaculty(int idFaculty);
  }
}
