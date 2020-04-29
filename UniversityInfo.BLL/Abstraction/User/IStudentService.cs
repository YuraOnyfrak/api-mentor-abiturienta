using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.BLL.Abstraction
{
    public interface IStudentService
    {
        Task<CreatedStudentDTO> UpdateAsync(UpdateStudentDTO entrant);
        Task<CreatedStudentDTO> CreateAsync(CreateStudentDTO entrant);
        Task<StudentDTO> GetAsync();
    }
}
