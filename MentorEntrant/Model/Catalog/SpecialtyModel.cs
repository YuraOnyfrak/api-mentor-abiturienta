using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.Model.Catalog
{
  public class SpecialtyModel
  {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpecialityByFacultyId { get; set; }
        public SpecialtyModel() { }

        public SpecialtyModel(SpecialityDTO dto)
        {
          this.Id = dto.Id;
          this.Name = dto.Name;
          this.SpecialityByFacultyId = dto.SpecialityByFacultyId;
        }
  }
}
