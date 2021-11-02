using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _72HrChallenge.Controllers
{
    public class PostController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreatePost([FromBody] Post modelPost)
        {
            if (modelPost == null)
            {
                return BadRequest("Your request body cannot be empty");
            }
            if (ModelState.IsValid)
            {
                _context.Users.Add(modelPost);
                await _context.SaveChangesAsync();
                return Ok("Post was created");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Post> posts = await _context.Users.ToListAsync();
            return Ok(posts);
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetPostById([FromUri] int id)
        {
            Post post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                return Ok(post);
            }
            return NotFound();
        }
        [HttpPut]
        public async Task<IHttpActionResult> UpdatePost([FromUri] int id, [FromBody] User updatedPost)
        {
            if (id != updatedpost?.PostId)
            {
                return BadRequest("User Ids do not match");
            }
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            Post post = await _context.Users.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            post.Title = updatedpost.Title;
            post.Text = updatedpost.Text;
            await _context.SaveChangesAsync();
            return Ok("The post was updated");
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeletePost([FromUri] int id)
        {
            Post post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return BadRequest("Post was not found.");
            }
            _context.Post.Remove(user);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The post was deleted");
            }
            return InternalServerError();
        }
    }
}
