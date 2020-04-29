using System;

namespace UniversityInfo.Shared.Exceptions
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
