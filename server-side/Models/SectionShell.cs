namespace server_side.Models;

public partial class SectionShell
{
    public long Id { get; set; }

    public long? SectionId { get; set; }

    public long? ShellId { get; set; }

    public long? ShellPosition { get; set; }

    public virtual Section? Section { get; set; }

    public virtual Shell? Shell { get; set; }
}
