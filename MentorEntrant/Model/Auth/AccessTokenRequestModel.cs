using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityInfo.Model
{
  public class AccessTokenRequestModel
  {
    public Guid Id { get; set; }
    public string Pin { get; set; }
    public string DeviceId { get; set; }
  }
}
