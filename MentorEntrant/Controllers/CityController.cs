using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.Model;

namespace MentorAbiturienta.Controllers
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
        
        public  async Task<ActionResult<IAsyncEnumerable<CityModel>>> GetAsync()
        {
          return Ok((await _cityService.GetAsync()).Select(s => new CityModel(s)));
        }
    }
}