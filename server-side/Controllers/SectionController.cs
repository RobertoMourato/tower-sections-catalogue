using server_side.Models;
using server_side.Interfaces;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using server_side.Dtos;

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

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SectionDto))]
        [ProducesResponseType(400)]
        public IActionResult GetSectionById(long id)
        {
            var section = mapper.Map<SectionDto>(sectionRepository.GetSection(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (section == null)
            {
                return NotFound();
            }

            return Ok(section);
        }

        [HttpGet("{partNumber}")]
        [ProducesResponseType(200, Type = typeof(SectionDto))]
        [ProducesResponseType(400)]
        public IActionResult GetSectionByPartNumber(string partNumber)
        {
            var section = mapper.Map<SectionDto>(sectionRepository.GetSection(partNumber));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (section == null)
            {
                return NotFound();
            }

            return Ok(section);
        }

        [HttpGet("{bottomDiameter:decimal?}/{topDiameter:decimal?}")]
        [ProducesResponseType(200, Type = typeof(ICollection<SectionDto>))]
        public IActionResult GetSectionsByDiameter(double? bottomDiameter = null, double? topDiameter = null)
        {
            var sections = mapper.Map<List<SectionDto>>(sectionRepository.GetSections(bottomDiameter, topDiameter));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sections);
        }
    }
}