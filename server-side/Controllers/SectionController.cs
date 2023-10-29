using server_side.Interfaces;
using server_side.Dtos;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace server_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IMapper mapper;

        public SectionController(ISectionRepository sectionRepository, IMapper mapper)
        {
            this.sectionRepository = sectionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<SectionDto>))]
        public IActionResult GetSections()
        {
            var sections = mapper.Map<List<SectionDto>>(sectionRepository.GetSections());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sections);
        }

        [HttpGet("{bottomDiameter:decimal?}/{topDiameter:decimal?}")]
        [ProducesResponseType(200, Type = typeof(ICollection<SectionDto>))]
        public IActionResult GetSections(double? bottomDiameter = null, double? topDiameter = null)
        {
            var sections = mapper.Map<List<SectionDto>>(sectionRepository.GetSections(bottomDiameter, topDiameter));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sections);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SectionInformationDto))]
        [ProducesResponseType(400)]
        public IActionResult GetSection(long id)
        {
            var section = mapper.Map<SectionDto>(sectionRepository.GetSection(id));

            if (section == null)
            {
                return NotFound();
            }

            var shells = mapper.Map<List<ShellDto>>(sectionRepository.GetShells(id));

            var sectionInformation = new SectionInformationDto(section, shells);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sectionInformation);
        }

        [HttpGet("{partNumber}")]
        [ProducesResponseType(200, Type = typeof(SectionInformationDto))]
        [ProducesResponseType(400)]
        public IActionResult GetSection(string partNumber)
        {
            var section = mapper.Map<SectionDto>(sectionRepository.GetSection(partNumber));

            if (section == null)
            {
                return NotFound();
            }

            var shells = mapper.Map<List<ShellDto>>(sectionRepository.GetShells(section.Id));

            var sectionInformation = new SectionInformationDto(section, shells);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sectionInformation);
        }
    }
}