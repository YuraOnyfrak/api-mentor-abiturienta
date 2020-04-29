using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityInfo.Shared
{
  public static class ThreadSafeList
  {
    private static readonly object _lock = new object();

    public static void AddThreadSafe(this List<int> collection, int value)
    {
      lock (_lock)
      {
        collection.Add(value);
      }
    }

    public static void AddRangeThreadSafe(this List<int> collection, IEnumerable<int> values)
    {
      lock (_lock)
      {
        collection.AddRange(values);
      }
    }

    public static bool ContainsThreadSafe(this List<int> collection, int value)
    {
      lock (_lock)
      {
        return collection.Contains(value);
      }
    }

    public static bool RemoveThreadSafe(this List<int> collection, int value)
    {
      lock (_lock)
      {
        return collection.Remove(value);
      }
    }

  }
}
