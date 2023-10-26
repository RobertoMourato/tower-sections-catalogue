using Microsoft.EntityFrameworkCore;
using server_side.Models;

namespace server_side.Database;

public class SqliteContext : DbContext
{
    public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
    { }

    public DbSet<Section> Sections { get; set; }

    public DbSet<Shell> Shells { get; set; }

    public DbSet<SectionShell> SectionShells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SectionShell>()
                .HasKey(ss => new { ss.SectionId, ss.ShellId });
        modelBuilder.Entity<SectionShell>()
                .HasOne(se => se.Section)
                .WithMany(ss => ss.SectionShells)
                .HasForeignKey(se => se.SectionId);
        modelBuilder.Entity<SectionShell>()
                .HasOne(sh => sh.Shell)
                .WithMany(ss => ss.SectionShells)
                .HasForeignKey(sh => sh.ShellId);
    }
}
