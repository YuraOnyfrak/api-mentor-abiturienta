using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO.Catalog;

namespace UniversityInfo.Model
{
  public class FacultyModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public FacultyModel() { }

    public FacultyModel(FacultyDTO faculty)
    {
      this.Id = faculty.Id;
      this.Name = faculty.Name;
    }
  }
}
