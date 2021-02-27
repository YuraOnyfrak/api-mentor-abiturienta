using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.BLL.Abstraction
{
  public interface IUniversityService
  {
    Task<IEnumerable<UniversityDTO>> GetByCityAsync(int cityId);
  }
}
