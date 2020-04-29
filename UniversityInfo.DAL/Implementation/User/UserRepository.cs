using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
    public UserRepository(IStorageContext context) : base(context)
    {
    }

    public User GetByPhone(string phoneNumber)
    {
      return null;//this.Context.Users.FirstOrDefault(s =>s.Phone.Equals(phoneNumber));
    }

    public bool IsExist(string phoneNumber)
    {
      return true;//this.Context.Users.Any(s => s.Phone.Equals(phoneNumber));
    }
  }
}
