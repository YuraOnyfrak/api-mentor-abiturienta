using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.BLL.Abstraction
{
  public interface ISmsSender
  {
    SendSmsResult SendSms(string to, string body);
  }
}
