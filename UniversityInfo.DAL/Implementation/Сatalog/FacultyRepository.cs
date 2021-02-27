using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Implementation
{
  public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
  {
    public FacultyRepository(IStorageContext context) : base(context)
    {
    }
  }
}
