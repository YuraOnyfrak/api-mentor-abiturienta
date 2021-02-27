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
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
          _facultyService = facultyService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns></returns>
        [HttpGet("{universityId}")]
        public async Task<IEnumerable<GroupedFaculty>> GetByUniversityAsync(int universityId)
        {
          return (await _facultyService.GetByUniversityAsync(universityId))
            .Select(s => new GroupedFaculty()
            {
              Letter = s.Key,
              Faculties = s.Select(p => new FacultyModel(p))
            });
        }
  }
}