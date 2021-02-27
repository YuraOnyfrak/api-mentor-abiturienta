using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Abstraction
{
  public interface ISpecialityRepository : IGenericRepository<Speciality>
  {
    IQueryable<Speciality> GetByFaculty(int idFaculty);
  }
}
