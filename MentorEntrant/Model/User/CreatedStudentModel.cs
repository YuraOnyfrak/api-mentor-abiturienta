using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.DTO;

namespace MentorAbiturienta.Model
{
  public class CreatedStudentModel
  {
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }

    public CreatedStudentModel() { }

    public CreatedStudentModel(CreatedStudentDTO entrant)
    {
      this.Id = entrant.Id;
      this.Firstname = entrant.Firstname;
      this.Lastname = entrant.Lastname;
    }
  }
}
