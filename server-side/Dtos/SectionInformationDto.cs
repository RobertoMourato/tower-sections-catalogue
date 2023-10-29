namespace server_side.Dtos
{
    public class SectionInformationDto
    {
        public SectionDto Section { get; set; }
        public List<ShellDto> Shells { get; set; }

        public SectionInformationDto(SectionDto section, List<ShellDto> shells)
        {
            this.Section = section;
            this.Shells = shells;
        }
    }
}