using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.BLL.Abstraction
{
  public interface IAccessDispatcher
  {
    Task<string> GenerateAccessTokenAsync(User user);
    Task<string> GenerateRefreshTokenAsync(int userId);
    ClaimsPrincipal Validate(string accessToken);
    Task<Token> ValidateRefreshTokenAsync(string refreshTokenId);
  }
}
