using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL.Domain
{
  public class Faculty : Identifiable
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int UniversityId { get; set;}
    public virtual University University { get; set; }
  }
}
