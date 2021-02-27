using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.BLL.DTO
{
  public class SpecializationDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public SpecializationDTO()
    {
    }

    public SpecializationDTO(Specialization specialization)
    {
      this.Id = specialization.Id;
      this.Name = specialization.Name;
    }
  }
}
