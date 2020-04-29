using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.Model.Catalog
{
  public class SpecialtyModel
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public SpecialtyModel() { }

    public SpecialtyModel(SpecialityDTO city)
    {
      this.Id = city.Id;
      this.Name = city.Name;
    }
  }
}
