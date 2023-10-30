using server_side.Interfaces;
using server_side.Dtos;
using server_side.Models;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace server_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IShellRepository shellRepository;
        private readonly IMapper mapper;

        public SectionController(ISectionRepository sectionRepository, IShellRepository shellRepository, IMapper mapper)
        {
            this.sectionRepository = sectionRepository;
            this.shellRepository = shellRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<SectionDto>))]
        public IActionResult GetSections()
        {
            var sections = mapper.Map<List<SectionDto>>(sectionRepository.GetSections());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            return Ok(sections);
        }

        [HttpGet("{bottomDiameter:decimal?}/{topDiameter:decimal?}")]
        [ProducesResponseType(200, Type = typeof(ICollection<SectionDto>))]
        public IActionResult GetSections(double? bottomDiameter = null, double? topDiameter = null)
        {
            var sections = mapper.Map<List<SectionDto>>(sectionRepository.GetSections(bottomDiameter, topDiameter));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sections);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SectionInformationDto))]
        [ProducesResponseType(400)]
        public IActionResult GetSection(long id)
        {
            var section = mapper.Map<SectionDto>(sectionRepository.GetSection(id));

            if (section == null)
                return NotFound();

            var shells = mapper.Map<List<ShellDto>>(sectionRepository.GetShells(id));

            var sectionInformation = new SectionInformationDto(section, shells);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sectionInformation);
        }

        [HttpGet("{partNumber}")]
        [ProducesResponseType(200, Type = typeof(SectionInformationDto))]
        [ProducesResponseType(400)]
        public IActionResult GetSection(string partNumber)
        {
            var section = mapper.Map<SectionDto>(sectionRepository.GetSection(partNumber));

            if (section == null)
                return NotFound();

            var shells = mapper.Map<List<ShellDto>>(sectionRepository.GetShells(section.Id));

            var sectionInformation = new SectionInformationDto(section, shells);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(sectionInformation);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSection([FromBody] SectionCreationInformationDto sectionInformation)
        {
            var newPartNumber = sectionInformation.PartNumber;
            var shellIds = sectionInformation.ShellIds;

            if (newPartNumber == null || shellIds.Count == 0)
                return BadRequest(ModelState);

            var searchSection = sectionRepository.GetSections().Where(se => se.PartNumber.Trim().ToUpper() == newPartNumber.Trim().ToUpper()).FirstOrDefault();

            if (searchSection != null)
            {
                ModelState.AddModelError("", "Section already exists");
                return StatusCode(422, ModelState);
            }

            double nextBottomDiameter = 0;
            double BottomDiameter = 0;
            double TopDiameter = 0;

            for (var i = 0; i < shellIds.Count; i++)
            {
                var shell = shellRepository.GetShell(shellIds[i]);

                if (shell == null)
                {
                    ModelState.AddModelError("", "Unexistent shell");
                    return StatusCode(500, ModelState);
                }

                if (i != 0)
                {
                    if (shell.BottomDiameter != nextBottomDiameter)
                    {
                        ModelState.AddModelError("", "Shell diameters must be continuous between adjacent shells");
                        return StatusCode(500, ModelState);
                    }
                }

                if (i == 0)
                    BottomDiameter = shell.BottomDiameter;

                if (i == shellIds.Count - 1)
                    TopDiameter = shell.TopDiameter;

                nextBottomDiameter = shell.TopDiameter;
            }

            var section = mapper.Map<Section>(new SectionDto(newPartNumber, BottomDiameter, TopDiameter));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!sectionRepository.CreateSection(section, shellIds))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}