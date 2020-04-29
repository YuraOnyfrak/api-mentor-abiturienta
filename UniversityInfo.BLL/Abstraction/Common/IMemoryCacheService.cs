using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UniversityInfo.Services.Abstractions
{
  public interface IMemoryCacheService
  {
    IList<string> Keys { get; }
    Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> defaultValueFunc);
    bool TryGetValue<T>(string key, out T value);
    void Remove(string key);
    void Remove(Func<string, bool> predicate);
    void Set<T>(string key, T value);
    object Get(string key);
    void RemoveRange(IEnumerable<string> keys);
   // Task CreateRangeAsync(IEnumerable<string> keys, IEnumerable<PermissionType> permissions);
  }
}
