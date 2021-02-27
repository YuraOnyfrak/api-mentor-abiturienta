using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;
using MentorAbiturienta.DAL.Domain;
using MentorAbiturienta.Shared.Options;

namespace MentorAbiturienta.DAL
{
  public class MentorAbiturientaContext : DbContext, IStorageContext
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StorageContext">StorageContext</see> class.
    /// </summary>
    /// <param name="connectionStringProvider">The connection string that is used to connect to the physical storage.</param>
    public MentorAbiturientaContext(IOptions<StorageContextOptions> options)
    {
      this.ConnectionString = options.Value.ConnectionString;
    }

    /// <summary>
    /// The connection string that is used to connect to the physical storage.
    /// </summary>
    public string ConnectionString { get; private set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);

      optionsBuilder.UseSqlServer(this.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Speciality>()
          .HasIndex(u => u.Code)
          .IsUnique();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Entrant> Entrants { get; set; }
    public DbSet<Student> Students { get; set; }
    
    public DbSet<RefreshToken> RefreshToken { get; set; }
    public DbSet<ValidationTicket> ValidationTickets { get; set; }
    
    public DbSet<University> Universities { get; set; }
    public DbSet<Speciality> Specialties { get; set; }
    public DbSet<SpecialityByFaculty> SpecialityByFaculty { get; set; }
    public DbSet<Specialization> Specializations { get; set; }    
    public DbSet<Faculty> Faculties { get; set; }    
    public DbSet<City> Cities { get; set; }
  }
}
