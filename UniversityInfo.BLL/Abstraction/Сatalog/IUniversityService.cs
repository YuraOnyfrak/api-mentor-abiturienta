using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.BLL.Abstraction
{
  public interface IUniversityService
  {
    Task<IEnumerable<UniversityDTO>> GetByCityAsync(int cityId);
  }
}
