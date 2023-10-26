using Microsoft.EntityFrameworkCore;

namespace server_side.Models;

public class SqliteContext : DbContext
{
    public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
    { }

    public DbSet<Section> Sections { get; set; }

    public DbSet<Shell> Shells { get; set; }

    public DbSet<SectionShell> SectionShells { get; set; }
}
