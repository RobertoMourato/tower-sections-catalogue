using System;
using System.Collections.Generic;

namespace server_side.Models;

public partial class Shell
{
    public long Id { get; set; }

    public double? Height { get; set; }

    public double? BottomDiameter { get; set; }

    public double? TopDiameter { get; set; }

    public double? Thickness { get; set; }

    public double? SteelDensity { get; set; }

    public virtual ICollection<SectionShell> SectionShells { get; set; } = new List<SectionShell>();
}
