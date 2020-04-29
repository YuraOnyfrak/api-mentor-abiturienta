using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.BLL.DTO.Catalog
{
  public class FacultyDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public FacultyDTO() { }

    public FacultyDTO(Faculty faculty)
    {
      this.Id = faculty.Id;
      this.Name = faculty.Name;
    }
  }
}
