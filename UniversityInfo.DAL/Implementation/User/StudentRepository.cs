using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class StudentRepository : GenericRepository<Student>, IStudentRepository
  {
    public StudentRepository(UniversityInfoContext context) : base(context)
    {
    }
  }
}
