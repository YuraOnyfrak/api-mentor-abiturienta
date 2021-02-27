using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO.Catalog;

namespace MentorAbiturienta.BLL.Abstraction
{
  public interface IFacultyService
  {
    Task<IEnumerable<IGrouping<char, FacultyDTO>>> GetByUniversityAsync(int universityId);
  }
}
