using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorAbiturienta.Model
{
  public class GroupedFaculty
  {
    public char Letter { get; set; }
    public IEnumerable<FacultyModel> Faculties { get; set; }  

  }
}
