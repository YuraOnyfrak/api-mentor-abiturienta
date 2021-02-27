using System;
using System.Collections.Generic;
using System.Text;

namespace MentorAbiturienta.BLL.DTO
{
  public class SendSmsResult
  {
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }

    public SendSmsResult(bool success, string errorMessage = null)
    {
      this.Success = success;
      this.ErrorMessage = errorMessage;
    }
  }
}
