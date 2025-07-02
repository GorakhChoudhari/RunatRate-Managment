
using RunAtRate.Appllication.DTOs;

namespace RunAtRate.infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<InspectionDto> Inspections { get; set; } = null!;
}
