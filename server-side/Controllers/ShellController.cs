using server_side.Interfaces;
using server_side.Dtos;
using server_side.Models;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace server_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShellController : ControllerBase
    {
        private readonly IShellRepository shellRepository;
        private readonly IMapper mapper;

        public ShellController(IShellRepository shellRepository, IMapper mapper)
        {
            this.shellRepository = shellRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<ShellDto>))]
        public IActionResult GetShells()
        {
            var shells = mapper.Map<List<ShellDto>>(shellRepository.GetShells());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(shells);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(SectionDto))]
        [ProducesResponseType(400)]
        public IActionResult GetShell(long id)
        {
            var shell = mapper.Map<ShellDto>(shellRepository.GetShell(id));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (shell == null)
                return NotFound();

            return Ok(shell);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateShell([FromBody] ShellDto newShell)
        {
            if (newShell == null)
                return BadRequest(ModelState);

            var shell = mapper.Map<Shell>(newShell);

            if (!shellRepository.CreateShell(shell))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteShell(int shellId)
        {
            var shellToDelete = shellRepository.GetShell(shellId);

            if (shellToDelete == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!shellRepository.DeleteShell(shellToDelete))
            {
                ModelState.AddModelError("", "Something went wrong upon deleting shell");
            }

            return NoContent();
        }
    }
}