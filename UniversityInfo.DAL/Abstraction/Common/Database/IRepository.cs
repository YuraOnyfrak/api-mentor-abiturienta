using System;
using System.Collections.Generic;
using System.Text;

namespace MentorAbiturienta.DAL
{
  public interface IRepository
  {
    /// <summary>
    /// Sets the storage context to work with.
    /// </summary>
    /// <param name="storageContext">The storage context to set.</param>
    void SetStorageContext(IStorageContext storageContext);
  }
}
