using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.Model.Catalog;

namespace UniversityInfo.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SpecialtyController : Controller
    {
        private readonly ISpecialityService _specialtyService;

        public SpecialtyController(ISpecialityService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns></returns>
        [HttpGet("{facultyId}")]
        public async Task<IEnumerable<SpecialtyModel>> GetByCityAsync(int facultyId)
        {
          return (await _specialtyService.GetByFacultyAsync(facultyId))
            .Select(s => new SpecialtyModel(s));
        }
  }
}