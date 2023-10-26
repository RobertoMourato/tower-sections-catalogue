using server_side.Data;
using server_side.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly SqliteContext sqliteContext;

        public SectionController(SqliteContext sqliteContext)
        {
            this.sqliteContext = sqliteContext;

        }

        //create
        [HttpPost]
        public async Task<ActionResult<List<Section>>> AddSection(Section newSection)
        {
            if (newSection != null)
            {
                sqliteContext.Sections.Add(newSection);
                await sqliteContext.SaveChangesAsync();
                return Ok(await sqliteContext.Sections.ToListAsync());
            }

            return BadRequest("Object instance not set");
        }
    }
}