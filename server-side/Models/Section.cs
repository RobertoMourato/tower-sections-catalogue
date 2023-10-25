namespace server_side.Models;

public partial class Section
{
    public long Id { get; set; }

    public string? PartNumber { get; set; }

    public double? BottomDiameter { get; set; }

    public double? TopDiameter { get; set; }

    public virtual ICollection<SectionShell> SectionShells { get; set; } = new List<SectionShell>();
}
