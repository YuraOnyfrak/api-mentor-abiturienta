using MentorAbiturienta.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.Model;
using MentorAbiturienta.Model.User;

namespace MentorAbiturienta.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
          _studentService = studentService;
        }

        [HttpPost]
        public async Task<CreatedStudentModel> UpdateAsync(CreateStudentModel entrant) =>
            new CreatedStudentModel(await _studentService.UpdateAsync(entrant.ToDTO()));

        [HttpGet]
        public async Task<StudentModel> GetAsync() =>
            new StudentModel(await _studentService.GetAsync());

        [HttpGet("search")]
        public async Task<StudentModel> SearchAsync(SearchStudentModel searchStudentModel) =>
           new StudentModel(await _studentService.SearchAsync(searchStudentModel));


    }
}
