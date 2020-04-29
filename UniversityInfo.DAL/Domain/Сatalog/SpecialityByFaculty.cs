using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityInfo.DAL.Domain
{
  public class SpecialityByFaculty
  {
    public int Id { get; set; }

    public int SpecialityId { get; set; }
    public virtual Speciality Speciality { get; set; }

    public int FacultyId { get; set; }
    public virtual Faculty Faculty { get; set; }
  }
}
