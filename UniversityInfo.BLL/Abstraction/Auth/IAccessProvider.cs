using System.Security.Claims;

namespace MentorAbiturienta.BLL.Abstraction.Auth
{
  public interface IAccessProvider
  {
    ClaimsPrincipal CurrentUser { get; }
    int? CurrentUserId { get; }
  }
}
