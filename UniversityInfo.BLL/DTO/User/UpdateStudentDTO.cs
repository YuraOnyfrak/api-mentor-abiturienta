using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityInfo.BLL.DTO
{
  public class UpdateStudentDTO
  {
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int SpecialityByFacultyId { get; set; }
    public int SpecializationId { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public int Course { get; set; }
    public bool CanHelp { get; set; }
  }
}
