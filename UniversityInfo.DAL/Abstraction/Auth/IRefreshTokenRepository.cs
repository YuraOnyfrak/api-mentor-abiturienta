using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Abstraction
{
  public interface IRefreshTokenRepository : IRepository, IGenericRepository<RefreshToken>
  {
    Task<RefreshToken> GetByIdAsync(string refreshTokenId);
    Task<RefreshToken> DeleteAsync(string id);
  }
}
