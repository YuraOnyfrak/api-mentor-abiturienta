using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.DAL.Abstraction.Auth;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation.Auth
{
  public class ValidationTicketRepository : GenericRepository<ValidationTicket>, IValidationTicketRepository
  {
    public ValidationTicketRepository(IStorageContext context) : base(context)
    {
    }

    public ValidationTicket WithKey(Guid id)
    {
      return Context.ValidationTickets.Find(id);
    }

    public bool IsExistByPhoneNumber(string phoneNumber, out ValidationTicket oldTicket)
    {
      oldTicket = Context.ValidationTickets.FirstOrDefault(t => string.Equals(t.PhoneNumber, phoneNumber));

      return oldTicket != null;
    }


    public async Task<ValidationTicket> DeleteAsync(Guid id)
    {
      var entity = await Context.ValidationTickets.FindAsync(id);
      if (entity != null)
      {
        Context.ValidationTickets.Remove(entity);
      }

      return entity;
    }
  }
}
