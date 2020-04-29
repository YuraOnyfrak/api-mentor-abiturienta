using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL.Domain
{
  public class University : Identifiable
  {
    public int Id { get; set; }

    public string Name { get; set; }
    public int CityId{ get; set; }

    public virtual City City { get; set; }
  }
}
