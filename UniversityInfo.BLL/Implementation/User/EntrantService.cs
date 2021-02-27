using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.BLL.Implementation
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
