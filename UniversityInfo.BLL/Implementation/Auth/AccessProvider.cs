using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using MentorAbiturienta.BLL.Abstraction.Auth;

namespace MentorAbiturienta.BLL.Implementation.Auth
{
  public class AccessProvider : IAccessProvider
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimsPrincipal CurrentUser => _httpContextAccessor.HttpContext.User;

    public int? CurrentUserId => int.TryParse(GetClaim(ClaimTypes.NameIdentifier)?.Value, out int userId) ? userId : (int?)null;

    public bool IsAccountant => bool.TryParse(GetClaim("isAccountant")?.Value, out bool isAccountant) ? isAccountant : false;

    public AccessProvider(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    private Claim GetClaim(string type) => CurrentUser.Claims.FirstOrDefault(c => string.Equals(c.Type, ClaimTypes.NameIdentifier));
  }
}
