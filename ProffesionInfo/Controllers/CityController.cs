using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.Model;

namespace UniversityInfo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
          _cityService = cityService;
        }

        [HttpGet]
        public  async Task<IEnumerable<CityModel>> GetAsync()
        {
          return (await _cityService.GetAsync()).Select(s => new CityModel(s));
        }
    }
}