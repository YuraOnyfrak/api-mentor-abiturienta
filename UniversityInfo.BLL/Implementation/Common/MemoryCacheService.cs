using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.Services.Abstractions;

namespace UniversityInfo.Services.Concrete
{
  public class MemoryCacheService : IMemoryCacheService
  {
    private readonly IMemoryCache _memoryCache;
    private readonly List<string> _keys;

    public IList<string> Keys => _keys;

    public MemoryCacheService(IMemoryCache memoryCache)
    {
      _memoryCache = memoryCache;
      _keys = new List<string>();
    }

    public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> defaultValueFunc)
    {
      if (!_keys.Contains(key))
        _keys.Add(key);

      return await _memoryCache.GetOrCreateAsync(key, entry => defaultValueFunc());
    }

    public bool TryGetValue<T>(string key, out T value)
    {
      if (!_keys.Contains(key))
      {
        value = default(T);
        return false;
      }

      T returnObject = _memoryCache.Get<T>(key);
      value = returnObject;

      return true;
    }

    public void Remove(string key)
    {
      _memoryCache.Remove(key);
      _keys.Remove(key);
    }

    public void Remove(Func<string, bool> predicate)
    {
      if (predicate is null)
        return;

      IList<string> removedKeys = new List<string>();

      foreach (string key in _keys)
      {
        if (predicate(key))
        {
          _memoryCache.Remove(key);
          removedKeys.Add(key);
        }
      }

      foreach (string removedKey in removedKeys)
        _keys.Remove(removedKey);
    }

    public void Set<T>(string key, T value)
    {
      if (!_keys.Contains(key))
        _keys.Add(key);

      _memoryCache.Set(key, value);
    }

    public object Get(string key)
    {
      return _memoryCache.Get(key);
    }

    public void RemoveRange(IEnumerable<string> keys)
    {
      _keys.RemoveAll(s => keys.Any(k => k == s));
      foreach (string key in keys)
      {
        _memoryCache.Remove(key);
      }

    }
  }
}
