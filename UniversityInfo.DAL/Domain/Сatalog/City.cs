using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Domain.Common;

namespace MentorAbiturienta.DAL.Domain
{
  public class City : Identifiable
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
