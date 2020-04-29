using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.Shared.Enums;

namespace UniversityInfo.BLL.DTO
{
  public class ContactDataDTO
  {
    public ContactDataType Type { get; set; }
    public string Value { get; set; }
  }
}
