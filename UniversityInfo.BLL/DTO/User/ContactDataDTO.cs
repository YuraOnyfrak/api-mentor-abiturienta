using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.Shared.Enums;

namespace MentorAbiturienta.BLL.DTO
{
  public class ContactDataDTO
  {
    public ContactDataType Type { get; set; }
    public string Value { get; set; }
  }
}
