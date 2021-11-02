using _72HrChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _72HrChallenge.Controllers
{
    public class LikeController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateLike([FromBody] Like model)
        {
            if (model == null)
            {
                return BadRequest("Your like body cannot be empty!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var postEntity = await _context.Posts.FindAsync(model.UserId);
            if (postEntity is null)
            {
                return BadRequest("The target User with the Id of " + model.UserId + "does not exsist.");
            }
            postEntity.Likes.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You liked the post {postEntity.PostId}");
            }
            return InternalServerError();
        }       
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteLike([FromUri] int id)
        {
            Like like= await _context.Likes.FindAsync(id);
            if (like == null)
            {
                return BadRequest("That like was not found.");
            }
            _context.Likes.Remove(like);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The like was deleted");
            }
            return InternalServerError();
        }
    }
}
