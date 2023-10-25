using server_side.Database;
using server_side.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace server_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

        }

        //create
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User newUser)
        {
            if (newUser != null)
            {
                appDbContext.Users.Add(newUser);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Users.ToListAsync());
            }

            return BadRequest("Object instance not set");
        }
    }
}