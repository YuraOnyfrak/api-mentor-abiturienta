using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Abstraction
{
  public interface ISpecializationRepository : IGenericRepository<Specialization>
  {
    IQueryable<Specialization> GetBySpeciality(int specialityId);
  }
}
