using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _72HrChallenge.Models
{
    public class Post
    {
        [Key, ForeignKey("PostId")]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<Comments> Comments { get; set; } = new List<Comments>();

        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
    }
}