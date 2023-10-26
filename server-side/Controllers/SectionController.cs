using server_side.Models;
using server_side.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace server_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository sectionRepository;

        public SectionController(ISectionRepository sectionRepository)
        {
            this.sectionRepository = sectionRepository;

        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Section>))]
        public IActionResult GetSections()
        {
            var sections = sectionRepository.GetSections();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sections);
        }

        [HttpGet("{partNumber}")]
        [ProducesResponseType(200, Type = typeof(Section))]
        [ProducesResponseType(400)]
        public IActionResult GetSection(string partNumber)
        {
            var section = sectionRepository.GetSectionByPartNumber(partNumber);

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
    }
}