using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.Shared;

namespace UniversityInfo.DAL
{
  public class Storage : IStorage
  {
    /// <summary>
    /// Gets the Entity Framework storage context.
    /// </summary>
    public IStorageContext StorageContext { get; private set; }

    public Storage(IStorageContext storageContext)
    {
      if (!(storageContext is DbContext))
        throw new ArgumentException("The storageContext object must be an instance of the Microsoft.EntityFrameworkCore.DbContext class.");

      this.StorageContext = storageContext;
    }

    /// <summary>
    /// Gets a repository of the given type.
    /// </summary>
    /// <typeparam name="T">The type parameter to find implementation of.</typeparam>
    /// <returns></returns>
    public TRepository GetRepository<TRepository>() where TRepository : IRepository
    {
      TRepository repository = ExtensionManager.GetInstance<TRepository>();

      if (repository != null)
        repository.SetStorageContext(this.StorageContext);

      return repository;
    }

    /// <summary>
    /// Commits the changes made by all the repositories.
    /// </summary>
    public void Save()
    {
      (this.StorageContext as DbContext).SaveChanges();
    }

    /// <summary>
    /// Asynchronously commits the changes made by all the repositories.
    /// </summary>
    public async Task SaveAsync()
    {
      await (this.StorageContext as DbContext).SaveChangesAsync();
    }
  }
}  