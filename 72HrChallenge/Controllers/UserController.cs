using _72HrChallenge.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _72HrChallenge.Controllers
{
    public class UserController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateUser([FromBody] User model)
        {
            if(model == null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Users.Add(model);
                await _context.SaveChangesAsync();
                return Ok("User was created");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<User> users = await _context.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetUserById([FromUri] int id)
        {
            User user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdateUser([FromUri] int id, [FromBody] User updatedUser)
        {
           if(id != updatedUser?.UserId)
            {
                return BadRequest("User Ids do not match");
            }
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            User user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.UserName = updatedUser.UserName;
            await _context.SaveChangesAsync();
            return Ok("The user was updated");
        }
        public async Task<IHttpActionResult> DeleteUser([FromUri] int id)
        {
            User user = await _context.Users.FindAsync(id);
            if(user == null)
            {
                return BadRequest("User was not found.");
            }
            _context.Users.Remove(user);
            if(await _context.SaveChangesAsync() == 1)
            {
                return Ok("The user was deleted");
            }
            return InternalServerError();
        }
    }
}
