using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.BLL.Abstraction
{
  public interface IAccessDispatcher
  {
    Task<string> GenerateAccessTokenAsync(User user);
    Task<string> GenerateRefreshTokenAsync(int userId);
    ClaimsPrincipal Validate(string accessToken);
    Task<Token> ValidateRefreshTokenAsync(string refreshTokenId);
  }
}
