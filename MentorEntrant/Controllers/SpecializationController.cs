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
    public class SpecializationController : Controller
    {
        private readonly ISpecializationService _specializationService;

        public SpecializationController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialityId"></param>
        /// <returns></returns>
        [HttpGet("{specialityId}")]
        public async Task<IEnumerable<SpecializationModel>> GetBySpecialityAsync(int specialityId)
        {
          return (await _specializationService.GetBySpecialityAsync(specialityId))
            .Select(s => new SpecializationModel(s));
        }
    }
}