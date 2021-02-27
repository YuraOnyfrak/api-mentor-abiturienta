using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Domain.Common;

namespace MentorAbiturienta.DAL.Domain
{
  public class RefreshToken : Identifiable
  {
    public string Id { get; set; }
    public int UserId { get; set; }
    public DateTime Created { get; set; }

    public virtual User User { get; set; }
  }
}
