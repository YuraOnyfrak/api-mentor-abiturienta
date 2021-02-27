using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Abstraction.Auth
{
  public interface IValidationTicketRepository : IGenericRepository<ValidationTicket>, IRepository
  {
    ValidationTicket WithKey(Guid id);
    bool IsExistByPhoneNumber(string phoneNumber, out ValidationTicket oldTicket);
    Task<ValidationTicket> DeleteAsync(Guid id);
  }
}
