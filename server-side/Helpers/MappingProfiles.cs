using server_side.Dtos;
using server_side.Models;

using AutoMapper;

namespace server_side.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Section, SectionDto>();
            CreateMap<Shell, ShellDto>();
        }
    }
}