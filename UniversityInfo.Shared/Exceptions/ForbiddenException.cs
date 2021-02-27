using System;

namespace MentorAbiturienta.Shared.Exceptions
{
  public class ForbiddenException : Exception
  {
    private string v;

    public ForbiddenException(string v)
    {
      this.v = v;
    }
  }
}
