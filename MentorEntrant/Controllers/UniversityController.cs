using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.Model;

namespace UniversityInfo.Controllers
{

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]    
    [ApiController]
    [Route("api/v1/[controller]")]    
    public class UniversityController : Controller
    {
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService)
        {
          _universityService = universityService;
        }    
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpGet("{cityId}")]
        public async Task<IEnumerable<UniversityModel>> GetByCityAsync(int cityId)
        {
          return (await _universityService.GetByCityAsync(cityId))
            .Select(s => new UniversityModel(s));
        }
    }
}