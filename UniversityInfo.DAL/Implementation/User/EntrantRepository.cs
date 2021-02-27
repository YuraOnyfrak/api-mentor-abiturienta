using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Implementation
{
  public class EntrantRepository : GenericRepository<Entrant>, IEntrantRepository
  {
    public EntrantRepository(MentorAbiturientaContext context) : base(context)
    {
    }
  }
}
