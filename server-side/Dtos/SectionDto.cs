namespace server_side.Dtos
{
    public class SectionDto
    {
        public long Id { get; set; }

        public string PartNumber { get; set; }

        public double BottomDiameter { get; set; }

        public double TopDiameter { get; set; }

        public SectionDto(string PartNumber, double BottomDiameter, double TopDiameter)
        {
            this.PartNumber = PartNumber;
            this.BottomDiameter = BottomDiameter;
            this.TopDiameter = TopDiameter;
        }
    }
}