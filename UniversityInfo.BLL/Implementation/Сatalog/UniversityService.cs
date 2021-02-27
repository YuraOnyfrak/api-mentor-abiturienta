using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL.Abstraction;

namespace MentorAbiturienta.BLL.Implementation
{
  public class UniversityService : IUniversityService
  {
    private readonly IUniversityRepository _universityRepository;

    public UniversityService(IUniversityRepository universityRepository)
    {
      _universityRepository = universityRepository;
    }

    public async Task<IEnumerable<UniversityDTO>> GetByCityAsync(int cityId)
    {
      return (await _universityRepository.GetByCityAsync(cityId))
        .Select(s => new UniversityDTO(s));
    }
  }
}
