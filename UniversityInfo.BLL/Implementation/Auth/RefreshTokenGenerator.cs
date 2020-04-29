using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace UniversityInfo.BLL.Implementation.Auth
{
  public class RefreshTokenGenerator
  {
    public string Generate()
    {
      byte[] randomNumber = new byte[32];

      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
      }
    }
  }
}
