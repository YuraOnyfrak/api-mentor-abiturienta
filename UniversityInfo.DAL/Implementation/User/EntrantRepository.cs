using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class EntrantRepository : GenericRepository<Entrant>, IEntrantRepository
  {
    public EntrantRepository(UniversityInfoContext context) : base(context)
    {
    }
  }
}
