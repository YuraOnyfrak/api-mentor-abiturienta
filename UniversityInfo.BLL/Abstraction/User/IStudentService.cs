using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.Model;

namespace MentorAbiturienta.BLL.Abstraction
{
    public interface IStudentService
    {
        Task<CreatedStudentDTO> UpdateAsync(UpdateStudentDTO entrant);
        Task<CreatedStudentDTO> CreateAsync(CreateStudentDTO entrant);
        Task<StudentDTO> GetAsync();
        Task<StudentDTO> SearchAsync(SearchStudentModel searchStudentModel);
    }
}
