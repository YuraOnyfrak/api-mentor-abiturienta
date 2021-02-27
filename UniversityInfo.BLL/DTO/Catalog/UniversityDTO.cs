using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.BLL.DTO
{
  public class UniversityDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public UniversityDTO()
    {
    }

    public UniversityDTO(University university)
    {
      this.Id = university.Id;
      this.Name = university.Name;
    }
  }
}
