using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace UniversityInfo.BLL.Abstraction
{
  public interface IJwtService
  {
    string Generate(IEnumerable<Claim> claims);
    ClaimsPrincipal Validate(string accessToken);
  }
}
