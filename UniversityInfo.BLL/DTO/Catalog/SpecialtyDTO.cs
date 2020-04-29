using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.BLL.DTO
{
  public class SpecialityDTO
  {
    public int Id { get; set; }
    public int SpecialityByFacultyId { get; set; }
    public string Name { get; set; }

    public SpecialityDTO()
    {
    }

    public SpecialityDTO(Speciality speciality)
    {
        this.Id = speciality.Id;
        this.Name = $"{speciality.Code} {speciality.Name}";
        this.SpecialityByFacultyId = speciality.SpecialityByFaculty.Id;
    }
  }
}
