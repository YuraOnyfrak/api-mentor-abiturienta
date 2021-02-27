using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentorAbiturienta.DAL
{
  public abstract class MigrationStorageContextFactory : IDesignTimeDbContextFactory<MentorAbiturientaContext>
  {
    public abstract MentorAbiturientaContext CreateDbContext(string[] args);
  }
}
