using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityInfo.BLL.Abstraction.Auth
{
  public interface IAccessTokensService
  {
    Guid GenerateValidationTicket(string phoneNumber, string IpAddress);
  }
}
