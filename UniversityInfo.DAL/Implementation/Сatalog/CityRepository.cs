using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class CityRepository : GenericRepository<City>, ICityRepository
  {
    public CityRepository(IStorageContext context) : base(context)
    {
    }
  }
}
