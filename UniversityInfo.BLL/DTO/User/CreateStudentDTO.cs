using System;
using System.Collections.Generic;
using System.Text;

namespace MentorAbiturienta.BLL.DTO
{
  public class CreateStudentDTO
  {
    public string TelegramId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string TelegramUsername { get; set; }
    public string TelegramPhotoUrl { get; set; }
  }
}
