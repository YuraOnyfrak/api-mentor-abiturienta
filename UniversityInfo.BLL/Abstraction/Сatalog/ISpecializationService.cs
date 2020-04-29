using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.BLL.Abstraction
{
  public interface ISpecializationService
  {
     Task<IEnumerable<SpecializationDTO>> GetBySpecialityAsync(int specialityId);
  }
}
