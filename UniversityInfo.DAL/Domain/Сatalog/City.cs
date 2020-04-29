using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL.Domain
{
  public class City : Identifiable
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
