using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MentorAbiturienta.DAL
{
  public interface IStorage
  {
    IStorageContext StorageContext { get; }

    T GetRepository<T>() where T : IRepository;
    void Save();
    Task SaveAsync();
  }
}
