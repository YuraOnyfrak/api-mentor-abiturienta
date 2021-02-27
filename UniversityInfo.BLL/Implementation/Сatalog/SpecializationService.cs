using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL.Abstraction;

namespace MentorAbiturienta.BLL.Implementation
{
  public class SpecializationService : ISpecializationService
  {
    private readonly ISpecializationRepository _specializationRepository;

    public SpecializationService(ISpecializationRepository specializationRepository)
    {
      _specializationRepository = specializationRepository;
    }

    public async Task<IEnumerable<SpecializationDTO>> GetBySpecialityAsync(int specialityId)
    {
      return (await _specializationRepository.GetBySpeciality(specialityId)
        .OrderBy(s => s.Name)
        .ToListAsync())
        .Select(s => new SpecializationDTO(s));
    }
  }
}
