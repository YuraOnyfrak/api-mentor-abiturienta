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
  public class CityService : ICityService
  {
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
      _cityRepository = cityRepository;
    }

    public async Task<IEnumerable<CityDTO>> GetAsync()
    {
      return (await _cityRepository.GetAllAsync()).Select(s => new CityDTO(s));
    }
  }
}
