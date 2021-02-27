using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.BLL.Abstraction
{
  public interface ISpecialityService
  {
    Task<IEnumerable<SpecialityDTO>> GetByFacultyAsync(int facultyId);
  }
}
