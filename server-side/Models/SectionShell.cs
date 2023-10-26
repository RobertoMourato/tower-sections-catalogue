namespace server_side.Models;

public class SectionShell
{
    public long Id { get; set; }

    public required long SectionId { get; set; }

    public required long ShellId { get; set; }

    public required long ShellPosition { get; set; }

    public required Section Section { get; set; }

    public required Shell Shell { get; set; }
}
