using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.BLL.DTO;
using UniversityInfo.DAL.Abstraction;

namespace UniversityInfo.BLL.Implementation
{
  public class SpecialityService : ISpecialityService
  {
    private readonly ISpecialityRepository _specialityRepository;

    public SpecialityService(ISpecialityRepository specialityRepository)
    {
      _specialityRepository = specialityRepository;
    }

    public async Task<IEnumerable<SpecialityDTO>> GetByFacultyAsync(int facultyId)
    {
      return (await _specialityRepository.GetByFaculty(facultyId)
                .Include(s=>s.SpecialityByFaculty)
                .OrderBy(s => s.Name)
                .ToListAsync())
                .Select(s => new SpecialityDTO(s));
    }
  }
}
