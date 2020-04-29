using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityInfo.DAL
{
  public abstract class MigrationStorageContextFactory : IDesignTimeDbContextFactory<UniversityInfoContext>
  {
    public abstract UniversityInfoContext CreateDbContext(string[] args);
  }
}
