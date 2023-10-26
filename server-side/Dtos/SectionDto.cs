namespace server_side.Dtos
{
    public class SectionDto
    {
        public required string PartNumber { get; set; }

        public required double BottomDiameter { get; set; }

        public required double TopDiameter { get; set; }
    }
}