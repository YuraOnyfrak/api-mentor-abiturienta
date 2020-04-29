using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.BLL.DTO;
using UniversityInfo.DAL;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.BLL.Implementation
{
  public class EntrantService : IEntrantService
  {
    private readonly IStorage _storage;
    private readonly IUserRepository _userRepository;

    public EntrantService
      (
      IStorage storage,
      IUserRepository userRepository
      )
    {
      _storage = storage;
      _userRepository = userRepository;
    }
  }
}
