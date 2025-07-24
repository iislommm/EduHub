using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class AppDbContextMS : DbContext
{
    public AppDbContextMS(DbContextOptions<AppDbContextMS> options)
     : base(options)
    {
    }

    public DbSet<Video> Videos { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Category> Categories { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
       typeof(AppDbContextMS).Assembly,
       t => t.Namespace == "Infrastructure.ConfigurationsMS"
   );
    }
}
