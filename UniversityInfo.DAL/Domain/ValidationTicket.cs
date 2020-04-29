﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL.Domain
{
  public class ValidationTicket : Identifiable
  {
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public DateTime? Used { get; set; }
    public string Pin { get; set; }
    public string IpAddress { get; set; }
    public string PhoneNumber { get; set; }
  }
}
