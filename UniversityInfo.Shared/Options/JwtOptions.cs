using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityInfo.Shared.Options
{
  public class JwtOptions
  {
    public string SecurityKey { get; set; }
    public int ExpiresInMinutes { get; set; }
  }
}
