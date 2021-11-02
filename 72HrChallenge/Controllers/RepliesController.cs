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
    public class RepliesController : ApiController
    {
        private readonly UserDbContext _context = new UserDbContext();
        [HttpPost]
        public async Task<IHttpActionResult> CreateReply([FromBody] Replies model)
        {
            if (model == null)
            {
                return BadRequest("Your reply body cannot be empty!");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var commentEntity = await _context.Comments.FindAsync(model.UserId);
            if (commentEntity is null)
            {
                return BadRequest("The target User with the Id of " + model.UserId + "does not exsist.");
            }
            commentEntity.Replies.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You replied to post {commentEntity.PostId}");
            }
            return InternalServerError();
        }
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            List<Replies> replies = await _context.Replies.ToListAsync();
            return Ok(replies);
        }    
        [HttpPut]
        public async Task<IHttpActionResult> UpdateReply([FromUri] int id, [FromBody] Replies updatedReply)
        {
            if (id != updatedReply?.ReplyId)
            {
                return BadRequest("Reply Ids do not match");
            }
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            Replies reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            reply.Text = updatedReply.Text;
            await _context.SaveChangesAsync();
            return Ok("The reply was updated");
        }
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteReply([FromUri] int id)
        {
            Replies reply = await _context.Replies.FindAsync(id);
            if (reply == null)
            {
                return BadRequest("Reply was not found.");
            }
            _context.Replies.Remove(reply);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok("The reply was deleted");
            }
            return InternalServerError();
        }
    }
}

