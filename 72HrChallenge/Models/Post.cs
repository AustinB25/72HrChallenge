using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        public Guid AuthorId { get; set; }
    }
}