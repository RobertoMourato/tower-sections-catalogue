namespace server_side.Models;

public class Shell
{
    public long Id { get; set; }

    public required double Height { get; set; }

    public required double BottomDiameter { get; set; }

    public required double TopDiameter { get; set; }

    public required double Thickness { get; set; }

    public required double SteelDensity { get; set; }

    public ICollection<SectionShell>? SectionShells { get; set; }
}
