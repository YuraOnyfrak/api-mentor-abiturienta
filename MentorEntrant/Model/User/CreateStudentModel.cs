using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.Model
{
  public class CreateStudentModel
  {
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int SpecialityByFacultyId { get; set; }
    public int SpecializationId { get; set; }
    public string Name  { get; set; }
    public string Lastname { get; set; }
    public int Course { get; set; }
    public string Instagram  { get; set; }
    public bool CanHelp { get; set; }

    public UpdateStudentDTO ToDTO() =>
      new UpdateStudentDTO()
      {
         UniversityId = this.UniversityId,
         FacultyId = this.FacultyId,
         SpecialityByFacultyId = this.SpecialityByFacultyId,
         SpecializationId = this.SpecializationId,
         Name = this.Name,
         Lastname = this.Lastname,
         Course = this.Course,
         CanHelp = this.CanHelp
      };
  }
}
