using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.BLL.DTO
{
  public class CityDTO
  {
    public int Id{ get; set; }
    public string Name { get; set; }

    public CityDTO(){}

    public CityDTO(City city)
    {
      this.Id = city.Id;
      this.Name = city.Name;
    }
  }
}
