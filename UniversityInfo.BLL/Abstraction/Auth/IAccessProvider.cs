using System.Security.Claims;

namespace UniversityInfo.BLL.Abstraction.Auth
{
  public interface IAccessProvider
  {
    ClaimsPrincipal CurrentUser { get; }
    int? CurrentUserId { get; }
  }
}
