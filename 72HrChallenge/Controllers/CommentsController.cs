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
    public class CommentsController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateComment([FromBody] Comments model)
        {
            if (model == null)
            {
                return BadRequest("The comment request body is empty");
            }
            if (ModelState.IsValid)
            {
                _context.Comments.Add(model);
                await _context.SaveChangesAsync();
                return Ok("Comment was created");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllComments()
        {
            List<Comments> comments = await _context.Comments.ToListAsync();
            return Ok(comments);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetCommentById([FromUri] int id)
        {
            Comments comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                return Ok(comment);
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateComment([FromUri] int id, [FromBody] Comments updatedComment)
        {
            if (id != updatedComment?.CommentId)
            {
                return BadRequest("Comment Ids do not match");
            }
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            Comments comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            comment.CommentText = updatedComment.CommentText;
            await _context.SaveChangesAsync();
            return Ok("The comment was updated");
        }

          [HttpDelete]
          public async Task<IHttpActionResult> DeleteComment([FromUri] int id)
          {
                Comments comment = await _context.Comments.FindAsync(id);
                if (comment == null)
                {
                    return BadRequest("Comment was not found.");
                }
                _context.Comments.Remove(comment);
                if (await _context.SaveChangesAsync() == 1)
                {
                    return Ok("The comment was deleted");
                }
                return InternalServerError();
          }

    }

}
