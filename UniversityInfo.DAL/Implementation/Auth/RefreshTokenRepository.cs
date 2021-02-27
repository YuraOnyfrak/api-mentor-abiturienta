using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.DAL.Implementation.Auth
{
  public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
  {
    public RefreshTokenRepository(IStorageContext context) : base(context)
    {
    }

    public async Task<RefreshToken> GetByIdAsync(string refreshTokenId) =>
      await Context.RefreshToken.Include(s=>s.User).FirstOrDefaultAsync(s=>s.Id.Equals(refreshTokenId));

    public async Task<RefreshToken> DeleteAsync(string id)
    {
      var entity = await Context.RefreshToken.FindAsync(id);
      if (entity != null)
      {
        Context.RefreshToken.Remove(entity);
      }

      return entity;
    }
  }
}
