namespace server_side.Dtos
{
    public class SectionCreationInformationDto
    {
        public required string PartNumber { get; set; }
        public required List<long> ShellIds { get; set; }
    }
}