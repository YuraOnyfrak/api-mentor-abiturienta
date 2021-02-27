using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Implementation
{
  public class CityRepository : GenericRepository<City>, ICityRepository
  {
    public CityRepository(IStorageContext context) : base(context)
    {
    }
  }
}
