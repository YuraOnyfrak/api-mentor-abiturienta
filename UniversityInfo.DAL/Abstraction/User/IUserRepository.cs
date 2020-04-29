using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Abstraction
{
  public interface IUserRepository : IGenericRepository<User>, IRepository
  {
    User GetByPhone(string phoneNumber);
    bool IsExist(string phoneNumber);
  }
}
