using Microsoft.EntityFrameworkCore;

namespace server_side.Models;

public partial class SqliteContext : DbContext
{
    public SqliteContext()
    {
    }

    public SqliteContext(DbContextOptions<SqliteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<SectionShell> SectionShells { get; set; }

    public virtual DbSet<Shell> Shells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("sections");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BottomDiameter).HasColumnName("bottom_diameter");
            entity.Property(e => e.PartNumber).HasColumnName("part_number");
            entity.Property(e => e.TopDiameter).HasColumnName("top_diameter");
        });

        modelBuilder.Entity<SectionShell>(entity =>
        {
            entity.ToTable("section_shell");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.SectionId).HasColumnName("section_id");
            entity.Property(e => e.ShellId).HasColumnName("shell_id");
            entity.Property(e => e.ShellPosition).HasColumnName("shell_position");

            entity.HasOne(d => d.Section).WithMany(p => p.SectionShells)
                .HasForeignKey(d => d.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(d => d.Shell).WithMany(p => p.SectionShells)
                .HasForeignKey(d => d.ShellId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Shell>(entity =>
        {
            entity.ToTable("shells");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BottomDiameter).HasColumnName("bottom_diameter");
            entity.Property(e => e.Height).HasColumnName("height");
            entity.Property(e => e.SteelDensity).HasColumnName("steel_density");
            entity.Property(e => e.Thickness).HasColumnName("thickness");
            entity.Property(e => e.TopDiameter).HasColumnName("top_diameter");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
