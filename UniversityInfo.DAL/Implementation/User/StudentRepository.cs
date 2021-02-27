using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Implementation
{
  public class StudentRepository : GenericRepository<Student>, IStudentRepository
  {
    public StudentRepository(MentorAbiturientaContext context) : base(context)
    {
    }
  }
}
