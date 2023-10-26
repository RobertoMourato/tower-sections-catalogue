namespace server_side.Models;

public class Section
{
    public long Id { get; set; }

    public required string PartNumber { get; set; }

    public required double BottomDiameter { get; set; }

    public required double TopDiameter { get; set; }

    public ICollection<SectionShell>? SectionShells { get; set; }
}
