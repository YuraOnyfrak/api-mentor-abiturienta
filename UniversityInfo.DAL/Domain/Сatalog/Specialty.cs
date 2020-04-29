using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Domain.Common;

namespace UniversityInfo.DAL.Domain
{
  public class Speciality : Identifiable
  {
        public int Id { get; set; }
        public string Name { get; set; }      
        public string Code { get; set; }
        
        public virtual SpecialityByFaculty SpecialityByFaculty { get; set; }

    }
}
