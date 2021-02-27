using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.Model
{
  public class UniversityModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public UniversityModel() { }

    public UniversityModel(UniversityDTO city)
    {
      this.Id = city.Id;
      this.Name = city.Name;
    }
  }
}

