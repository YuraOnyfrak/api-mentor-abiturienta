using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.BLL.Abstraction
{
  public interface ISpecializationService
  {
     Task<IEnumerable<SpecializationDTO>> GetBySpecialityAsync(int specialityId);
  }
}
