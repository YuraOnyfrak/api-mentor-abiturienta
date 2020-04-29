using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL.Domain
{
  public class RefreshToken : Identifiable
  {
    public string Id { get; set; }
    public int UserId { get; set; }
    public DateTime Created { get; set; }

    public virtual User User { get; set; }
  }
}
