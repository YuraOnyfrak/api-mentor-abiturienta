using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.BLL.Abstraction
{
  public interface ISmsSender
  {
    SendSmsResult SendSms(string to, string body);
  }
}
