using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO.Catalog;

namespace UniversityInfo.BLL.Abstraction
{
  public interface IFacultyService
  {
    Task<IEnumerable<IGrouping<char, FacultyDTO>>> GetByUniversityAsync(int universityId);
  }
}
