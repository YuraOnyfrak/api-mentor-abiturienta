using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO.Catalog;

namespace MentorAbiturienta.Model
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
