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
    public class PostController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreatePost([FromBody] Post modelPost)
        {
            if(modelPost == null)
            {
                return BadRequest("Your post body cannot be empty!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userEntity = await _context.Users.FindAsync(modelPost.UserId);
            if(userEntity is null)
            {
                return BadRequest("The target User with the Id of "+ modelPost.UserId + "does not exsist.");
            }
            userEntity.Posts.Add(modelPost);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"{userEntity.UserName} just made a post.");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Post> posts = await _context.Posts.ToListAsync();
            return Ok(posts);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetPostById([FromUri] int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdatePost([FromUri] int id, [FromBody] Post updatedPost)
        {
            if (id != updatedPost?.PostId)
            {
                return BadRequest("User Ids do not match");
            }
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            Post post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            post.Title = updatedPost.Title;
            post.Text = updatedPost.Text;
            await _context.SaveChangesAsync();
            return Ok("The post was updated");
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePost([FromUri] int id)
        {
            Post post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return BadRequest("Post was not found.");
            }
            _context.Posts.Remove(post);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The post was deleted");
            }
            return InternalServerError();
        }
    }
}
